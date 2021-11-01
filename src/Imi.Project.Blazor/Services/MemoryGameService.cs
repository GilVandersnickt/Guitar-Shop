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
            var uniqueCards = new List<MemoryGameCard>();
            uniqueCards.Add(new MemoryGameCard() { number = 1, color = Color.red.ToString() });
            uniqueCards.Add(new MemoryGameCard() { number = 2, color = Color.green.ToString() });
            uniqueCards.Add(new MemoryGameCard() { number = 3, color = Color.blue.ToString() });
            uniqueCards.Add(new MemoryGameCard() { number = 4, color = Color.yellow.ToString() });
            uniqueCards.Add(new MemoryGameCard() { number = 5, color = Color.cyan.ToString() });
            uniqueCards.Add(new MemoryGameCard() { number = 6, color = Color.orange.ToString() });
            uniqueCards.Add(new MemoryGameCard() { number = 7, color = Color.pink.ToString() });
            uniqueCards.Add(new MemoryGameCard() { number = 8, color = Color.lightblue.ToString() });
            uniqueCards.AddRange(uniqueCards.Select(c => new MemoryGameCard() { number = c.number, color = c.color }).ToList());
            var cardPairs = uniqueCards.OrderBy(x => Guid.NewGuid()).ToList();


            Cards = new List<List<MemoryGameCard>>();
            for (int i = 0; i < 16; i++)
            {
                if (i % 4 == 0)
                {
                    Cards.Add(new List<MemoryGameCard>());
                }
                Cards[i / 4].Add(cardPairs[i]);
            }
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
            card.flipped = true;

            await Task.Delay(100);
            FlippedCards.Add(card);

            if (FlippedCards.Count() % 2 == 0)
            {
                var lastTwo = FlippedCards.TakeLast(2);
                var last = lastTwo.Last();
                var secondLast = lastTwo.First();

                if (last.number != secondLast.number)
                {
                    await Task.Delay(600);
                    FailedAttempts++;
                    last.flipped = false;
                    secondLast.flipped = false;
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
    }
}
