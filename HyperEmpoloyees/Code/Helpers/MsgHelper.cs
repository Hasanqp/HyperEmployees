using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Code.Helpers
{
    public static class MsgHelper
    {
        public static void ShowServerError()
        {
            MessageBox.Show("Возникла проблема с подключением к серверу, Пожалуйста, попробуйте снова",
                    "Недостаток общения."
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowRequiredFields()
        {
            MessageBox.Show("все поля, содержащие *, являются обязательными для заполнения, убедитесь, что вы ввели их, и повторите попытку позже",
                    "Обязательные для заполнения поля"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDuplicatedItems()
        {
            MessageBox.Show("эти данные уже были добавлены, обязательно измените поля, а затем повторите попытку",
                    "Повторяющиеся данные"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowEmptyDataGridView()
        {
            MessageBox.Show("Для выполнения этой операции необходимо выбрать данные",
                    "выбрать данные"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDeleteSelectRow()
        {
            MessageBox.Show("для деликатности процедуры удаления необходимо указать всю строку целиком",
                    "Удалите данные"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowDeleteDialog()
        {
            var result = MessageBox.Show("Вы уверены, что эта процедура не позволит восстановить данные?",
                    "Удалите данные"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ShowNumberVaild()
        {
            MessageBox.Show("Введите только числовое значение",
                    "Неверный ввод"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
