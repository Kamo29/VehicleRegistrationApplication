namespace ExerciseWindowsForms
{
    class Vehicle :IComparer<Vehicle> // Nice interface to inherit if you want to compare values and sort
    {
        string name, service;
        string price, outstanding;
        int milage, id;

        protected Vehicle(string name, string price, string outstanding, string service, int milage, int id)
        {
            this.Name = name;
            this.Price = price;
            this.Outstanding = outstanding;
            this.Service = service;
            this.Milage = milage;
            this.Id = id;
        }
      
        public Vehicle()
        {

        }
        public string Name { get => name; set => name = value; }
        public string Price { get => price; set => price = value; }
        public string Outstanding { get => outstanding; set => outstanding = value; }
        public string Service { get => service; set => service = value; }
        public int Milage { get => milage; set => milage = value; }
        public int Id { get => id; set => id = value; }

        //methods to be overriden in subclasses
        public virtual List<Vehicle> CalculateDiscount(List<Vehicle> VehicleList)
        {
            return VehicleList;
        }

        //Sorting method
        public int Compare(Vehicle x, Vehicle y)//Use lightbulb to create method
        {

            //Will return int values based on comparison
            if (x.Name == y.Name)
            {
                return 0;//Indicates names are the same
            }
            return x.Name.CompareTo(y.Name);
            
        }
    }
}
