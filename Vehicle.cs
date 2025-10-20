namespace ExerciseWindowsForms
{
    class Cars : Vehicle
    {
        public Cars(string name, string price, string outstanding, string service, int milage, int id) : base(name, price, outstanding, service, milage,id)
        {
        }
        public Cars()
        {

        }
        public List<Cars> Car(List<Vehicle> VehicleList)
        {
            List<Cars> CarsList = new List<Cars>();
            foreach (var item in VehicleList)
            {
                if (item is Cars)
                {
                    CarsList.Add(item as Cars);
                }
            }

            return CarsList;
        }
        public override List<Vehicle> CalculateDiscount(List<Vehicle> VehicleList)
        {

            //10% discount
            foreach (var item in VehicleList)
            {
                if (item is Cars)
                {
                    item.Outstanding = (double.Parse(item.Outstanding) * 0.90).ToString();
                }
            }

            return VehicleList;
        }
    }
}
