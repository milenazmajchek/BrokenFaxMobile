using BrokenFaxMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokenFaxMobile.Services
{
    public class MockDataStoreActiveThreads : IDataStore<ActiveFaxThreadData>
    {
        public static int CurrentUserId = 1234;

        readonly List<ActiveFaxThreadData> items;

        public MockDataStoreActiveThreads()
        {
            items = new List<ActiveFaxThreadData>()
            {
                new ActiveFaxThreadData{ Id = Guid.NewGuid().ToString(), CreatorName="Pera", GroupName="Bla", NextId = 1234, Length=6, NextName="Toma", Remaining=2, Updated=DateTime.Now },
                new ActiveFaxThreadData{ Id = Guid.NewGuid().ToString(), CreatorName="Zikica", GroupName="Bla", NextId = 1234, Length=6, NextName="Toma", Remaining=3, Updated=DateTime.Now },
                new ActiveFaxThreadData{ Id = Guid.NewGuid().ToString(), CreatorName="Toma", GroupName="Bla", NextId = 126, Length=4, NextName="Pera", Remaining=1, Updated=DateTime.Now }
            };
        }

        public async Task<bool> AddItemAsync(ActiveFaxThreadData item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ActiveFaxThreadData item)
        {
            var oldItem = items.Where((ActiveFaxThreadData arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ActiveFaxThreadData arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ActiveFaxThreadData> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ActiveFaxThreadData>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<ActiveFaxThreadData> GetActiveThreadsAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

    }
    public class MockDataStoreCompleted : IDataStore<CompleteThreadData>
    {
        public static int CurrentUserId = 1234;

        readonly List<CompleteThreadData> items;

        public MockDataStoreCompleted()
        {
            items = new List<CompleteThreadData>()
            {
                new CompleteThreadData{ Id = Guid.NewGuid().ToString(), CreatorName="Pera", GroupName="Bla", Term = "Poljski wc", Updated=DateTime.Now },
                new CompleteThreadData{ Id = Guid.NewGuid().ToString(), CreatorName="Zikica", GroupName="Bla", Term = "kajmak", Updated=DateTime.Now },
                new CompleteThreadData{ Id = Guid.NewGuid().ToString(), CreatorName="Toma", GroupName="Bla", Term = "Satira", Updated=DateTime.Now }
            };
        }

        public async Task<bool> AddItemAsync(CompleteThreadData item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CompleteThreadData item)
        {
            var oldItem = items.Where((CompleteThreadData arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((CompleteThreadData arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<CompleteThreadData> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CompleteThreadData>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<CompleteThreadData> GetActiveThreadsAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

    }

    public class MockDataStoreItem : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStoreItem()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}