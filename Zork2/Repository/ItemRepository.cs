using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;

namespace Zork2.Repository
{
    public class ItemRepository
    {
        //-------------------------------------------------------------------------------------------------------------------//

        public void SetItems(string itemName, int value)
        {
            var item = new Item(itemName, value);

            using (var context = ApplicationDbContext.Create())
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
        }
    }
}