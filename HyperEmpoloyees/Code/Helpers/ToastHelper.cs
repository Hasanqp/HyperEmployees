using HyperEmpoloyees.Gui.ToastGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Code.Helpers
{
    public static class ToastHelper
    {
        public static void ShowAddToast()
        {
            ToastForm.Instance("Добавить данные", "данные были успешно добавлены").Show();
        }

        public static void ShowEditToast()
        {
            ToastForm.Instance("Изменение данных", "данные были успешно изменены").Show();
        }

        public static void ShowDeleteToast()
        {
            ToastForm.Instance("Удалить данные", "Данные были успешно удалены").Show();
        }
    }
}
