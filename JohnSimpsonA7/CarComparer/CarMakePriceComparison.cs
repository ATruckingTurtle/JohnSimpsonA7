using JohnSimpsonA7.CarNameSpace;

namespace JohnSimpsonA7.CarComparer
{
    public class CarMakePriceComparison : IComparer<Car>
    {
        public int Compare(Car? x, Car? y)
        {
            try
            {
                if ((x != null) && (y != null))
                {
                    {
                        var makeCompare = string.Compare(x.Make, y.Make, StringComparison.CurrentCultureIgnoreCase);
                        if (makeCompare == 0)
                        {
                            return x.Price.CompareTo(y.Price);
                        }

                        return makeCompare;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Error comparing make and price: {e.Message}");
            }

            return 0;
        }
    }
}
