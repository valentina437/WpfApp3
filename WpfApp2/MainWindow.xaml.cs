using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Button_Click(Object sender, RoutedEventArgs e)
            {
                int correctAnswers = 0;
                correctAnswers += CheckRadioButtonAnswer("1", "C#");
                correctAnswers += CheckRadioButtonAnswer("2", "1524");
                correctAnswers += CheckRadioButtonAnswer("3", "1");
                correctAnswers += CheckRadioButtonAnswer("4", "6");
                MessageBox.Show($"Правильных ответов: {correctAnswers} из 4");
            }
            private int CheckRadioButtonAnswer(string groupName, string correctAnswer)
            {

                foreach (RadioButton rb in FindVisualChildren<RadioButton>(this))
                {
                    if (rb.GroupName == groupName && rb.IsChecked == true)
                    {
                        return rb.Content.ToString() == correctAnswer ? 1 : 0;
                    }
                }
                return 0; // Или другое значение, если ни одна кнопка не выбрана 
            }
            public static System.Collections.Generic.IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            yield return (T)child;
                        }
                        foreach (T childOfChild in FindVisualChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }
    }


    