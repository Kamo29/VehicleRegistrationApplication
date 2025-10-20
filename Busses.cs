namespace ExerciseWindowsForms
{
    class Busses : Vehicle//Class comes from vehicle class
    {
        public Busses(string name, string price, string outstanding, string service, int milage, int id) : base(name, price, outstanding, service, milage, id)
        {
        }
        public Busses()
        {

        }
        public List<Busses> Bus(List<Vehicle> VehicleList)//Creating a Buss List from the busses in the Vehicle List
        {
            List<Busses> BussesList = new List<Busses>();
            foreach (var item in VehicleList)
            {
                if (item is Busses)
                {
                    BussesList.Add(item as Busses);
                }
            }

            return BussesList;
        }

        public override List<Vehicle> CalculateDiscount(List<Vehicle> VehicleList)
        {
            //15% discount
            foreach (var item in VehicleList)
            {
                if (item is Busses)
                {
                    item.Outstanding = (double.Parse(item.Outstanding) * 0.85).ToString();
                }
            }

            return VehicleList;
        }
    }
}
