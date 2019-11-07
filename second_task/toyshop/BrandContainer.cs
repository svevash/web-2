using System.Collections.Generic;

namespace toyshop
{
    public class BrandContainer
    {
        private Dictionary<Brand, List<int>> _brands;

        public Dictionary<Brand, List<int>> Brands
        {
            get => _brands;
            set => _brands = value;
        }

        public BrandContainer()
        {
            _brands = new Dictionary<Brand, List<int>>();
        }
    }
}