# VT Manager
Система включает в себя следующие компоненты для работы: 
1. Сам ARM-клиент VT Manager являющийся графическим представлением данных из базы предприятия и служащий для внесения изменений в базу посредством использования графического интерфейса.
2. Веб-часть системы, которая содержит набор всех необходимых скриптов связи базы с приложением, а также сам сайт для клиентов.
3. Библиотека шифрования данных и взаимодействия с Mysql.

-=== ОПИСАНИЕ ===-
Приложение VT Manager представляет собой АРМ-клиент, предназначенный для централизованного управления учётом производства и продажи вакуумных ламп, учреждённых определённой фирмой.
Целью разработки приложения является возможность корпоративной работы офиса продаж, быстрое освоение приложения и навигации в нём, подбор только необходимого функционала, повышение производительности за счёт многопоточности и использование шаблона архитектуры приложения MVVM. Приложение использует локальный сервер OpenServer для взаимодействия с базой и ведением сайта, также есть возможность работы и на арендованном сервере.
Для реализации графического интерфейса пользователя была использована система Windows Presentation Foundation (WPF).

-=== УСТАНОВКА И ЗАПУСК (локальный сервер) ===-
1. Установить open_server_5_3_5_ultimate.exe
2. Настроить модули OpenServer: HTTP - Apache_2.4-PHP_5.5-5.6, PHP - PHP_5.5, MySQL / MariaDB - MySQL-5.5-x64.
3. Переместить папку vtmanager.ru из архива web.zip в папку :  папка_установленного_openserver\OSPanel\domains.
4. Войти в phpMyAdmin с помощью OpenServer. Данные для входа - Логин : root, Пароль не указывать.
5. Создать в phpMyAdmin пустую базу данных с именем "vtmanager" и импортировать приложенный файл vtmanager.sql
6. Распаковать архив Release в любое удобное место на диске.
7. Скопировать файл VTManager.exe из распакованной папки Release и вставить на рабочий стол как ярлык.
8. Перезапустить OpenServer от имени администратора, включить сервер.
9. Запустить VTManager.exe, ввести тестовые данные - Логин : Admin, Пароль : 1111.

-=== ДЛЯ РАЗРАБОТЧИКОВ ===-
1. Переместить все файлы проекта в среду Visual Studio, либо клонировать данный репозиторий
2. Добавить к проекту MySQL Connector .NET (MySql.Data.dll)
3. Выполнить пункты 1-4 из "УСТАНОВКА И ЗАПУСК "

