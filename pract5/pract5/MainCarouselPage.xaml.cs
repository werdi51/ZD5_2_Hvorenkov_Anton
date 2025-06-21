using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace pract5
{
    public partial class MainCarouselPage : CarouselPage
    {
        public MainCarouselPage()
        {
            InitializeComponent();
        }

        public static string FullName { get; private set; }

        private void OnSignInClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameEntry.Text) ||
                string.IsNullOrWhiteSpace(lastNameEntry.Text))
            {
                DisplayAlert("Ошибка", "Заполните все поля", "OK");
                return;
            }

            FullName = $"{firstNameEntry.Text} {lastNameEntry.Text}";

            var secondPage = Children[1] as ContentPage;
            var welcomeLabel = secondPage.FindByName<Label>("welcomeLabel");
            welcomeLabel.Text = $"Добро пожаловать,\n{FullName}!";

            CurrentPage = secondPage;
        }

        private void OnGoToDataScreenClicked(object sender, EventArgs e)
        {
            // Переходим на третий экран
            CurrentPage = Children[2];
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = itemPicker.SelectedItem?.ToString() ?? "не выбрано";
                var maxSliderValue = valueSlider.Value;

                string explanation;
                switch (selectedItem)
                {
                    case "Вариант 1":
                        explanation = $"Вы выбрали 1 вариант, поздравляю {FullName}";
                        break;
                    case "Вариант 2":
                        explanation = $"Вы выбрали 2 вариант, вы молодец {FullName}";
                        break;
                    case "Вариант 3":
                        explanation = $"Вы выбрали 3 вариант, вы крутой {FullName}";
                        break;
                    default:
                        explanation = "Неизвестный вариант";
                        break;
                }

                resultLabel.Text = $"Пользователь: {FullName}\n" +
                                 $"Выбрано: {selectedItem}\n" +
                                 $"Характеристика: {explanation}\n" +
                                 $"значение слайдера: {maxSliderValue}";
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        }
    }
