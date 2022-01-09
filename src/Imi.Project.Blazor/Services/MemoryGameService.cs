using Imi.Project.Blazor.Enums;
using Imi.Project.Blazor.Models;
using Imi.Project.Blazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class MemoryGameService : IMemoryGameService
    {
        public List<List<MemoryGameCard>> Cards { get; set; }
        public List<MemoryGameCard> FlippedCards = new List<MemoryGameCard>();
        protected bool flipping = false;

        public int FailedAttempts;
        public int Wins;


        public void StartGame()
        {
            var cardPairs = GetCardPairs();
            Cards = GetCardsList(cardPairs);
        }
        public void ResetGame()
        {
            FailedAttempts = 0;
            StartGame();
        }

        public async Task Flip(MemoryGameCard card)
        {
            if (flipping) return;

            flipping = true;
            card.Flipped = true;

            await Task.Delay(100);
            FlippedCards.Add(card);

            if (FlippedCards.Count() % 2 == 0)
            {
                var lastTwo = FlippedCards.TakeLast(2);
                var last = lastTwo.Last();
                var secondLast = lastTwo.First();

                if (last.Number != secondLast.Number)
                {
                    await Task.Delay(600);
                    FailedAttempts++;
                    last.Flipped = false;
                    secondLast.Flipped = false;
                    FlippedCards.Remove(last);
                    FlippedCards.Remove(secondLast);
                }
            }
            if (FlippedCards.Count() == 16)
            {
                FlippedCards.Clear();
                await Task.Delay(600);
                Wins++;
                StartGame();
            }
            flipping = false;
        }
        private Color[] GetRandomColorList()
        {
            Random rnd = new Random();
            var colors = (Color[])Enum.GetValues(typeof(Color));
            return colors.OrderBy(x => rnd.Next()).ToArray();
        }
        private List<MemoryGameCard> GetCardPairs()
        {
            var uniqueCards = new List<MemoryGameCard>();
            var colors = GetRandomColorList();

            for (int i = 1; i < 9; i++)
            {
                uniqueCards.Add(new MemoryGameCard() { Number = i, Color = colors[i].ToString() });
            }
            uniqueCards.AddRange(uniqueCards.Select(c => new MemoryGameCard() { Number = c.Number, Color = c.Color }).ToList());

            return uniqueCards.OrderBy(x => Guid.NewGuid()).ToList();
        }
        private List<List<MemoryGameCard>> GetCardsList(List<MemoryGameCard> cardPairs)
        {
            var cards = new List<List<MemoryGameCard>>();
            for (int i = 0; i < 16; i++)
            {
                if (i % 4 == 0)
                {
                    cards.Add(new List<MemoryGameCard>());
                }
                cards[i / 4].Add(cardPairs[i]);
            }
            return cards;
        }

    }
}
