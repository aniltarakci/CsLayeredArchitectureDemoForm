using Business;
using DataAccess;
using Entities;

namespace FormAppLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductManager productManager = new ProductManager(new ProductDal());

            dgvList.DataSource = productManager.GetAll();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductManager productManager = new ProductManager(new ProductDal());
            productManager.Add(new Product { CategoryId = Convert.ToInt32(tbxCategoryId.Text), ProductName = tbxProductName.Text, UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text), UnitsInStock = Convert.ToInt32(tbxUnitsInStock.Text) });
            MessageBox.Show("Ürün eklendi.");
            dgvList.DataSource = productManager.GetAll();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            ProductManager productManager = new ProductManager(new ProductDal());
            productManager.Update(new Product { Id = Convert.ToInt32(tbxProductId.Text), CategoryId = Convert.ToInt32(tbxCategoryId.Text), ProductName = tbxProductName.Text, UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text), UnitsInStock = Convert.ToInt32(tbxUnitsInStock.Text) });
            MessageBox.Show("Ürün güncellendi.");
            dgvList.DataSource = productManager.GetAll();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            ProductManager productManager = new ProductManager(new ProductDal());
            productManager.Delete(new Product { Id = Convert.ToInt32(tbxProductId.Text) });
            MessageBox.Show("Ürün silindi.");
            dgvList.DataSource = productManager.GetAll();
        }
    }
}