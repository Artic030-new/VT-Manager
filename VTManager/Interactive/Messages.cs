using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager.Interactive
{
    public struct Messages {
        public const string
            _WARNING_MESSAGE = "Внимание",
            _ERROR_MESSAGE = "Ошибка",
            _OK_MESSAGE = "Успешно",

            _NO_ENTRY_SELECTED = "Выберите запись в таблице!",
            _NOT_ENOUGH_ITEMS = "Недостаточно номенклатуры на складе",
            _ATTEMPT_TO_CANCEL_SOLVED = "Завершенный заказ нельзя отменить",
            _ORDER_HAS_BEEN_SOLVED = "Заказ уже был завершен",
            _PROCESS_HAS_BEEN_SOLVED = "Процесс уже был завершен",
            _BRAND_NOT_REGISTERED = "Наличие партии не согласовано! Уточните информацию у кладовщика",
            _CLIENT_NOT_SELECTED = "Клиент не выбран",
            _COST_ABOVE_ZERO = "Параметр Цена должен быть числом > 0.",
            _FACT_ABOVE_ZERO = "Параметр Факт должен быть числом > 0.",
            _COST_NOT_SET = "Значение Цена не указано",
            _FACT_NOT_SET = "Значение Факт не указано",
            _ENTER_THE_COST = "Введите цену в документе: ",
            _FIELDS_NOT_FILLED = "Заполните все поля!",
            _PRODUCED_VT_FACT = "Введите фактическое кол-во произведённых ламп: ",
            _CONNECTION_IS_DONE = "Соединение установлено!",
            _CONNECTION_IS_LOST = "Соединение потеряно",
            _USER_IS_NULL = "Пользователя не существует",
            _MUTEX_IS_DUPLICATED = "Приложение уже запущено";
            
    }
}
