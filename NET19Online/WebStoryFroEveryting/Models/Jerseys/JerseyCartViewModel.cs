using Microsoft.AspNetCore.Mvc;

namespace WebStoryFroEveryting.Models.Jerseys
{
    public class JerseyCartViewModel
    {

        public List<JerseyCartItemViewModel> Items { get; set; } = new List<JerseyCartItemViewModel>();
        public decimal GrandTotal => Items.Sum(item => item.Total);
        public int TotalCountOfItems => Items.Sum(item => item.Quantity);
        public void AddItem([FromForm] JerseyCartItemViewModel item)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void IncrementItem(int id)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == id);
            if (existingItem != null)
            {
                existingItem.Quantity ++;
            }
        }
        public void DecrementItem(int id)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == id);
            if (existingItem != null)
            {
                if(existingItem.Quantity > 1)
                {
                    existingItem.Quantity--;
                }
                else
                {
                    RemoveItem(id);
                }
                  
            }
        }

        public void RemoveItem(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
    }
}
