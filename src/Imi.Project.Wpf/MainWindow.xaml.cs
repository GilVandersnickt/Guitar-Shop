using Imi.Project.Wpf.ApiModels.Brand;
using Imi.Project.Wpf.ApiModels.Category;
using Imi.Project.Wpf.ApiModels.Login;
using Imi.Project.Wpf.ApiModels.Product;
using Imi.Project.Wpf.ApiModels.Subcategory;
using Imi.Project.Wpf.Constants;
using Imi.Project.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Imi.Project.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;
        WpfService wpfService = new WpfService();
        private string token;

        public MainWindow(IHttpClientFactory httpClientFactory)
        {
            InitializeComponent();
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private async void Login()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            var request = new LoginApiRequest { UserName = username, Password = password };
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync("auth/login", content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var loginResponse = await JsonSerializer.DeserializeAsync<LoginApiResponse>(responseStream);
                    var result = await Task.FromResult(loginResponse);
                    token = result.Token;
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    this.Dispatcher.Invoke(() =>
                    {
                        lblFeedbackLogin.Content = "Successfully logged in";
                        EnableCrudTabs();
                        GetDataFromApi();
                    });
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase, "Invalid username or password", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void GetDataFromApi()
        {
            var responseProducts = await _httpClient.GetAsync("Products");
            var responseBrands = await _httpClient.GetAsync("Brands");
            var responseCategories = await _httpClient.GetAsync("Categories");
            var responseSubcategories = await _httpClient.GetAsync("Subcategories");
            // Products
            if (responseProducts.IsSuccessStatusCode)
            {
                using var responseStream = await responseProducts.Content.ReadAsStreamAsync();
                var products = await JsonSerializer.DeserializeAsync<IEnumerable<ProductApiResponse>>(responseStream);
                PopulateProductsInComboBoxes(products);
                PopulateProductsInListBox(products);
            }
            else
            {
                ShowFeedback(responseProducts.ReasonPhrase);
            }
            // Brands
            if (responseBrands.IsSuccessStatusCode)
            {
                using var responseStream = await responseBrands.Content.ReadAsStreamAsync();
                var brands = await JsonSerializer.DeserializeAsync<IEnumerable<BrandApiResponse>>(responseStream);
                PopulateBrandsInComboBoxes(brands);
            }
            else
            {
                ShowFeedback(responseBrands.ReasonPhrase);
            }
            // Categories
            if (responseCategories.IsSuccessStatusCode)
            {
                using var responseStream = await responseCategories.Content.ReadAsStreamAsync();
                var categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryApiResponse>>(responseStream);
                PopulateCategoriesInComboBoxes(categories);
            }
            else
            {
                ShowFeedback(responseCategories.ReasonPhrase);
            }
            // Subcategories
            if (responseSubcategories.IsSuccessStatusCode)
            {
                using var responseStream = await responseSubcategories.Content.ReadAsStreamAsync();
                var subcategories = await JsonSerializer.DeserializeAsync<IEnumerable<SubcategoryApiResponse>>(responseStream);
                PopulateSubcategoriesInComboBoxes(subcategories);
            }
            else
            {
                ShowFeedback(responseSubcategories.ReasonPhrase);
            }
        }
        private void ShowFeedback(string message)
        {
            MessageBox.Show(message);
        }
        private void EnableCrudTabs()
        {
            tabLogin.IsEnabled = false;
            tabRead.IsSelected = true;
            tabRead.IsEnabled = true;
            tabCreate.IsEnabled = true;
            tabUpdate.IsEnabled = true;
            tabDelete.IsEnabled = true;
        }
        #region Buttons
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }
        private void btnShowAdminCredentials_Click(object sender, RoutedEventArgs e)
        {
            if (lblAdminUsername.Content == null)
            {
                lblAdminUsername.Content = $"Admin username: {AdminCredentials.Username}";
                lblAdminPassword.Content = $"Admin password: {AdminCredentials.Password}";
                txtUsername.Text = AdminCredentials.Username;
                txtPassword.Password = AdminCredentials.Password;
            }
            else
            {
                lblAdminUsername.Content = null;
                lblAdminPassword.Content = null;
                txtUsername.Text = null;
                txtPassword.Password = null;
            }
        }
        private async void btnSaveCreatedProduct_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNameCreate.Text) && !string.IsNullOrEmpty(txtPriceCreate.Text) && !string.IsNullOrEmpty(txtImageCreate.Text) && cmbBrandCreate != null && cmbCategoryCreate != null && cmbSubcategoryCreate != null)
            {
                var brand = (BrandApiResponse)cmbBrandCreate.SelectedItem;
                var category = (CategoryApiResponse)cmbCategoryCreate.SelectedItem;
                var subcategory = (SubcategoryApiResponse)cmbSubcategoryCreate.SelectedItem;

                Uri imageUri = Uri.IsWellFormedUriString(txtImageCreate.Text, UriKind.Absolute) ? new Uri(txtImageCreate.Text) : new Uri("https://" + txtImageCreate.Text);             

                var request = new ProductApiRequest
                {
                    Name = txtNameCreate.Text.ToString(),
                    Image = imageUri, 
                    Price = txtPriceCreate.Text.ToString(),
                    BrandId = brand.Id,
                    CategoryId = category.Id,
                    SubcategoryId = subcategory.Id
                };
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                try
                {
                    var response = await _httpClient.PostAsync("Products", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Product {request.Name} was created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show(response.ReasonPhrase, "Failed to create product", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please make sure all fields are filled in", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void btnSaveEditedPruduct_Click(object sender, RoutedEventArgs e)
        {
            if(cmbProductsUpdate.SelectedItem != null)
            {
                var product = (ProductApiResponse)cmbProductsUpdate.SelectedItem;
                var brand = (BrandApiResponse)cmbBrandUpdate.SelectedItem;
                var category = (CategoryApiResponse)cmbCategoryUpdate.SelectedItem;
                var subcategory = (SubcategoryApiResponse)cmbSubcategoryUpdate.SelectedItem;

                Uri imageUri = Uri.IsWellFormedUriString(txtImageEdit.Text, UriKind.Absolute) ? new Uri(txtImageEdit.Text) : new Uri("https://" + txtImageEdit.Text);

                var request = new ProductApiRequest
                {
                    Id = product.Id,
                    Name = txtNameEdit.Text,
                    Image = imageUri,
                    Price = txtPriceEdit.Text.ToString(),
                    BrandId = brand.Id,
                    CategoryId = category.Id,
                    SubcategoryId = subcategory.Id
                };
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                try
                {
                    var response = await _httpClient.PutAsync("Products", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Product {request.Name} was edited successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show(response.ReasonPhrase, "Failed to edit product", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if(cmbProductsDelete.SelectedItem != null)
            {
                var product = (ProductApiResponse)cmbProductsDelete.SelectedItem;

                try
                {
                    var response = await _httpClient.DeleteAsync("Products/" + product.Id);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Product {product.Name} was deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show(response.ReasonPhrase, "Failed to delete product", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        #endregion
        #region SelectionChanged
        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = (ProductApiResponse)lstProducts.SelectedItem;
            if (product != null)
            {
                ShowProductDetails(product);
            }
        }
        private void cmbProductsUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = (ProductApiResponse)cmbProductsUpdate.SelectedItem;
            if (product != null)
            {
                txtNameEdit.Text = product.Name;
                txtImageEdit.Text = product.Image.ToString();
                txtPriceEdit.Text = product.Price.ToString();
                cmbBrandUpdate.SelectedItem = wpfService.GetFromComboBox<BrandApiResponse>(product.Brand, cmbBrandUpdate);
                cmbCategoryUpdate.SelectedItem = wpfService.GetFromComboBox<CategoryApiResponse>(product.Category, cmbCategoryUpdate);
                cmbSubcategoryUpdate.SelectedItem = wpfService.GetFromComboBox<SubcategoryApiResponse>(product.Subcategory, cmbSubcategoryUpdate);
            }
        }
        #endregion
        #region Population
        private void ShowProductDetails(ProductApiResponse product)
        {
            imgProductImage.Source = new BitmapImage(product.Image);
            lblProductName.Content = product.Name;
            lblProductPrice.Content = product.Price;
            lblProductBrand.Content = product.Brand;
            lblProductCategory.Content = product.Category;
            lblProductSubcategory.Content = product.Subcategory;
        }
        private void PopulateProductsInListBox(IEnumerable<ProductApiResponse> products)
        {
            lstProducts.Items.Clear();
            foreach (var product in products)
            {
                lstProducts.Items.Add(product);
            }
        }
        private void PopulateProductsInComboBoxes(IEnumerable<ProductApiResponse> products)
        {
            cmbProductsUpdate.ItemsSource = products;
            cmbProductsDelete.ItemsSource = products;
        }
        private void PopulateBrandsInComboBoxes(IEnumerable<BrandApiResponse> brands)
        {

            cmbBrandCreate.ItemsSource = brands;
            cmbBrandUpdate.ItemsSource = brands;
        }
        private void PopulateCategoriesInComboBoxes(IEnumerable<CategoryApiResponse> categories)
        {
            cmbCategoryCreate.ItemsSource = categories;
            cmbCategoryUpdate.ItemsSource = categories;
        }
        private void PopulateSubcategoriesInComboBoxes(IEnumerable<SubcategoryApiResponse> subcategories)
        {
            cmbSubcategoryCreate.ItemsSource = subcategories;
            cmbSubcategoryUpdate.ItemsSource = subcategories;
        }
        #endregion
        #region Regex
        private void txtPriceCreate_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtPriceEdit_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion
    }
}
