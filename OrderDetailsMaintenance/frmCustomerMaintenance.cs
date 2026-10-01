using OrderDetailsMaintenance.Models.DataLayer;

namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        //Wes Johnson
        private NorthwindContext _context;
        private Customer _customer;
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        //Wes Johnson
        private void btnFind_Click(object sender, EventArgs e)
        {
            _context = new NorthwindContext();
            _customer = _context.Customers.Find(txtCustomerId.Text);

            if (_customer != null)
            {
                txtContact.Text = _customer.ContactName;
                txtAddress.Text = _customer.Address;
                txtCity.Text = _customer.City;
                txtCountry.Text = _customer.Country;
            }
            else
            {
                MessageBox.Show("CustomerId was misspelled or doesn't exist");
            }
        }

        //Wes Johnson
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Wes Johnson
        private void btnSave_Click(object sender, EventArgs e)
        {
            _customer.CustomerId = txtCustomerId.Text;
            _customer.ContactName = txtContact.Text;
            _customer.Address = txtAddress.Text;
            _customer.City = txtCity.Text;
            _customer.Country = txtCountry.Text;

            _context.Customers.Update(_customer);
            _context.SaveChanges();

        }
    }
}