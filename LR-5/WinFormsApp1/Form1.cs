// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System.Numerics;
using System.Security.Cryptography;

namespace WinFormsApp1
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
        private void button1_Click(object sender, EventArgs e)
        {

        }

		static BigInteger ModularExponentiation(BigInteger a, BigInteger e, BigInteger m)
		{
			BigInteger result = 1;
			while (e != 0)
			{
				if (e % 2 == 1)
					result = (result * a) % m;

				e = e / 2;
				a = (a * a) % m;
			}

			return result;
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void button1_Click_2(object sender, EventArgs e)
		{
			try
			{
				BigInteger a = Convert.ToInt64(textBox1.Text);
				BigInteger x = Convert.ToInt64(textBox2.Text);
				BigInteger m = Convert.ToInt64(textBox3.Text);
				if ((a<0  || x<0 || m < 0) && a>0)
				{
                    MessageBox.Show("Введите положительные числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
                }
				// Вычисляем a^x mod m
				BigInteger result = ModularExponentiation(a, x, m);

				// Отображаем результат в textBox4
				textBox4.Text = $"Результат: {result}";
			}
			catch (FormatException)
			{
				MessageBox.Show("Введите корректные числовые значения в поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (OverflowException)
			{
				MessageBox.Show("Введенное число слишком большое", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				if (BigInteger.TryParse(textBox7.Text, out BigInteger a) && BigInteger.TryParse(textBox6.Text, out BigInteger b))
				{
					BigInteger gcd = GCD(a, b);

					textBox5.Text = $"НОД({a}, {b}) = {gcd}";
				}
				else
				{
					MessageBox.Show("Введите корректные числовые значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private BigInteger GCD(BigInteger a, BigInteger b)
		{
			while (b != 0  )
				{
					BigInteger temp = b;
					b = a % b;
					a = temp;
			}
			return a;
		}

		private void label13_Click(object sender, EventArgs e)
		{

		}
		private BigInteger ModInverse(BigInteger a, BigInteger m)
		{
			BigInteger m0 = m;
			BigInteger x0 = 0;
			BigInteger x1 = 1;
			BigInteger y0 = x1;
			//y0 = 0;
			int b = 1;

			if (m == 1)
				return 0;

			while (m.CompareTo(BigInteger.One) == 1)
			{
				BigInteger q = a.Divide(m);

				BigInteger t = m;

				m = a % m;
				a = t;
				t = x0;
				x0 = x1 - q * x0;
				x1 = t;
			}

			while (x1.CompareTo(BigInteger.Zero) == -1)
				x1 = x1.Add(m0);

			return x1;
		}
		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				if (BigInteger.TryParse(textBox13.Text, out BigInteger x) && BigInteger.TryParse(textBox12.Text, out BigInteger m))
				{
					BigInteger result = ModInverse(x, m);

					textBox11.Text = result.ToString();
				}
				else
				{
					MessageBox.Show("Введите корректные числа в textBox13 и textBox12");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Произошла ошибка: Для данного числа не существует обратного");
			}
		}

		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void textBox9_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox8_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				if (BigInteger.TryParse(textBox9.Text, out BigInteger n) && BigInteger.TryParse(textBox10.Text, out BigInteger a))
				{
					bool isPrime = FermatTest(n, a);

					if (isPrime)
						textBox8.Text = "True";
					else
						textBox8.Text = "False"; 
				}
				else
				{
					MessageBox.Show("Введите корректные числа в textBox9 и textBox10");
				}
			}
			catch (Exception ex)
			{
				// Обработка общих исключений
				MessageBox.Show($"Произошла ошибка: {ex.Message}");
			}
		}
		private bool FermatTest(BigInteger n, BigInteger a)
		{
			// Проверка, что a и n > 1
			if (a <= 1 || n <= 1)
				return false;

			// Вычисление a^(n-1) mod n
			BigInteger result = BigInteger.ModPow(a, n - 1, n);

			// Если результат не равен 1, то a не является свидетелем простоты
			return result == 1;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				if (BigInteger.TryParse(textBox15.Text, out BigInteger n))
				{
					bool isProbablyPrime = MillerRabinTest(n);

					if (isProbablyPrime)
						textBox14.Text = $"{n} вероятно простое число по тесту Миллера-Рабина";
					else
						textBox14.Text = $"{n} не является простым числом по тесту Миллера-Рабина";
				}
				else
				{
					MessageBox.Show("Введите корректное число в textBox15");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Произошла ошибка: {ex.Message}");
			}
		}
		private bool MillerRabinTest(BigInteger n)
		{
			if (n <= 1)
				return false;

			BigInteger d = n - 1;
			int s = 0;

			while (d % 2 == 0)
			{
				d /= 2;
				s++;
			}
			int numberOfIterations = 20;

			Random random = new Random();

			for (int i = 0; i < numberOfIterations; i++)
			{
				BigInteger a = RandomBigInteger(2, n - 2, random);
				BigInteger x = BigInteger.ModPow(a, d, n);
				if (x == 1 || x == n - 1)
					continue;

				for (int r = 1; r < s; r++)
				{
					x = BigInteger.ModPow(x, 2, n);

					if (x == 1)
						return false;

					if (x == n - 1)
						break;
				}

				if (x != n - 1)
					return false;
			}

			return true;
		}
		private BigInteger RandomBigInteger(BigInteger min, BigInteger max, Random random)
		{
			byte[] bytes = new byte[max.ToByteArray().Length];
			random.NextBytes(bytes);
			BigInteger value = new BigInteger(bytes);
			return BigInteger.Remainder(BigInteger.Add(BigInteger.Abs(value), min), max - min) + min;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			try
			{
				int bitLength = GetRandomBitLength();

				BigInteger primeNumber = GeneratePrimeNumber(bitLength);

				textBox16.Text = primeNumber.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Произошла ошибка: {ex.Message}");
			}
		}
		private int GetRandomBitLength()
		{
			Random random = new Random();
			return random.Next(100, 512); 
		}
		private BigInteger GeneratePrimeNumber(int bitLength)
		{
			using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
			{
				while (true)
				{
					byte[] bytes = new byte[(bitLength + 7) / 8];
					rng.GetBytes(bytes);
					BigInteger candidate = new BigInteger(bytes);

					candidate |= BigInteger.One << (bitLength - 1);

					if (MillerRabinTest(candidate))
						return candidate;
				}
			}
		}
	}
}