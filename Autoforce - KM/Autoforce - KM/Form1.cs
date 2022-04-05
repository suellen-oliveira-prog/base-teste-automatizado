using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
namespace Autoforce___KM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(textBox1.Text);
            //Teste do campo em branco
            driver.FindElement(By.CssSelector(".form__control-select__placeholder")).Click();
            driver.FindElement(By.Id("react-select-2-option-0")).Click();
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            Assert.That(driver.FindElement(By.Id("bouncer-error_used_vehicle[km]")).Text, Is.EqualTo("Por favor, preencha esse campo"));
            //Validação do campo.
            driver.FindElement(By.Id("used_vehicle_km")).Click();
            driver.FindElement(By.Id("used_vehicle_km")).SendKeys("123456789-123");
            driver.FindElement(By.CssSelector(".form__control-select__value-container")).Click();
            driver.FindElement(By.Id("react-select-2-option-1")).Click();
            driver.FindElement(By.Id("used_vehicle_km")).Click();
            {
                string value = driver.FindElement(By.Id("used_vehicle_km")).GetAttribute("value");
                Assert.That(value, Is.EqualTo("123.456.789 Km"));
            }
            driver.Quit();
            MessageBox.Show("Todos os testes foram efetuados com sucesso");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(textBox1.Text);
            driver.FindElement(By.Id("used_vehicle_km")).Click();
            driver.FindElement(By.Id("used_vehicle_km")).SendKeys("123456789-123");
            driver.FindElement(By.CssSelector(".form__control-select__value-container")).Click();
            driver.FindElement(By.Id("react-select-2-option-1")).Click();
            driver.FindElement(By.Id("used_vehicle_km")).Click();
            {
                string value = driver.FindElement(By.Id("used_vehicle_km")).GetAttribute("value");
                Assert.That(value, Is.EqualTo("123.456.789 Km"));
            }
            driver.Quit();
            MessageBox.Show("Campo limita corretamente a 9 números.");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(textBox1.Text);
            driver.FindElement(By.Id("used_vehicle_km")).Click();
            driver.FindElement(By.Id("used_vehicle_km")).SendKeys("abcdefg teste");
            driver.FindElement(By.CssSelector(".form__control-select__value-container")).Click();
            driver.FindElement(By.Id("react-select-2-option-1")).Click();
            driver.FindElement(By.Id("used_vehicle_km")).Click();
            {
                string value = driver.FindElement(By.Id("used_vehicle_km")).GetAttribute("value");
                Assert.That(driver.FindElement(By.Id("bouncer-error_used_vehicle[km]")).Text, Is.EqualTo("Por favor, preencha esse campo"));
            }
            driver.Quit();
            MessageBox.Show("Campo permanece em branco, mesmo após tentar inserir caracteres.");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(textBox1.Text);
            driver.FindElement(By.CssSelector(".form__control-select__placeholder")).Click();
            driver.FindElement(By.Id("react-select-2-option-0")).Click();
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            Assert.That(driver.FindElement(By.Id("bouncer-error_used_vehicle[km]")).Text, Is.EqualTo("Por favor, preencha esse campo"));
            driver.Quit();
            MessageBox.Show("A mensagem de campo em branco está correta!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
