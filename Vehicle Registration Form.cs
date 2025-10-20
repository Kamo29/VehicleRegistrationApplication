namespace ExerciseWindowsForms
{
    public partial class Form1 : Form
    {
        List<Vehicle> VehicleList = new List<Vehicle>();
        BindingSource bs = new BindingSource();//Binds to the lists
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//when the form loads up
        {
            //Created an instance of the vehicle class here in order to used the sorting method created within
            Vehicle v = new Vehicle();
            //Created instances of sub classes to apply discounts
            Cars c = new Cars();
            Busses b = new Busses();

            //You can see that above I was using default/Empty constructors to achieve this

            Cars Camry = new Cars("Toyota Camry", "50000.00", "30000.00", "2023/05/05", 100000,1);
            Cars Corola = new Cars("Toyota Corola", "60000.00", "35000.00", "2023/06/05", 110000,2);
            Busses Mercedes = new Busses("Mercedes Benz", "750000.00", "550000.00", "2022/02/02", 150000,3);
            Busses Scania = new Busses("Scania", "700000.00", "500000.00", "2022/02/05", 160000,4);
            VehicleList.Add(Camry);
            VehicleList.Add(Corola);
            VehicleList.Add(Mercedes);
            VehicleList.Add(Scania);


            //Applying discounts
            VehicleList = c.CalculateDiscount(VehicleList);
            VehicleList = b.CalculateDiscount(VehicleList);

            //Adding R symbol to indicate rand for displaying purposes
            foreach (var item in VehicleList)
            {
                item.Price = "R " + item.Price;
                item.Outstanding = "R " + item.Outstanding;
            }

            //This will sort my Vehicle list based on the Vehicle name
            //Need to supply this sort method with a reference to the class that contains the compare method. In this case it was the Vehicle class
            VehicleList.Sort(v);

            //Display in dataGridView
            bs.DataSource = VehicleList;
            dataGridView1.DataSource = bs;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Pretty straight forward
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Display all vehicles
            bs.DataSource = VehicleList;
            //dataGridView1.DataSource = "";
            dataGridView1.DataSource = bs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Display only cars
            Cars car = new Cars();
            List<Cars> Carlist = car.Car(VehicleList);

            bs.DataSource = Carlist;
            //dataGridView1.DataSource = "";
            dataGridView1.DataSource = bs;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Display only busses
            Busses bus = new Busses();
            List<Busses> Buslist = bus.Bus(VehicleList);

            bs.DataSource = Buslist;
            //dataGridView1.DataSource = "";
            dataGridView1.DataSource = bs;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool found = false;

            //Search for vehicle with specific ID
            foreach (var item in VehicleList)
            {
                if (item.Id == int.Parse(textBox1.Text))
                {
                    //Displays values in labels if found
                    found = true;
                    lblName.Text = item.Name;
                    lblMilage.Text = item.Milage.ToString();
                    lblService.Text = item.Service;
                    lblPrice.Text = item.Price;
                    lblOutstanding.Text = item.Outstanding;
                }
            }
            //display message if not found
            if (found == false)
            {
                MessageBox.Show("Vehicle not found");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
