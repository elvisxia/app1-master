using System;
using System.Collections.ObjectModel;

namespace App1
{
    public class ProductCollection
    {
        public ObservableCollection<ProductGroup> _groupsletter;

        public ObservableCollection<ProductGroup> GroupByLetter
        {
            get
            {
                if (_groupsletter == null)
                {
                    _groupsletter = new ObservableCollection<ProductGroup>();
                }

                return _groupsletter;
            }
        }

        public void Add(Product newitem)
        {
            AddToLetterGroup(newitem);
        }

        public void CreateNewGroupByLetter(ObservableCollection<ProductGroup> oldGroupByLetter)
        {
            if (oldGroupByLetter != null&&this.GroupByLetter!=null)
            {
                foreach (var group in oldGroupByLetter)
                {
                    foreach (var product in group)
                    {
                        Add(new Product {
                             Name=product.Name
                        });
                    }
                }
            }
        }

        private void AddToLetterGroup(Product item)
        {
            int i;
            ProductGroup prodgr = null;

            // get group from letter
            for(i = 0; i < _groupsletter.Count; i++)
            {
                if (String.Equals(_groupsletter[i].Key, item.Name[0].ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    prodgr = _groupsletter[i];
                    break;
                }
            }

            //new letter
            if (prodgr == null)
            {
                prodgr = new ProductGroup();
                prodgr.Key = item.Name[0].ToString();
                prodgr.Add(item);
                _groupsletter.Add(prodgr);
            }
            else
            {
                prodgr.Add(item);
            }
        }
    }

    public class ProductGroup : ObservableCollection<Product>
    {
        public string Key { get; set; }
    }
}