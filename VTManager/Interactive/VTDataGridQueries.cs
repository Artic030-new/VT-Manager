﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager.Interactive
{
    class VTDataGridQueries
    {
        public static VTQuery query = new VTQuery();
        /* Запросы к поискам*/
        public static string processingQuery = "SELECT processing.shift, personal.firstName, vt.mark, processing.date, processing.count, processing.plan, processing.fact, processing.done FROM personal JOIN (vt JOIN processing ON vt.id = processing.vtId) ON personal.id = processing.personalId";
        public static string unsolvedProcessingQuery = "SELECT processing.shift, personal.firstName, vt.mark, processing.date, processing.count, processing.plan FROM personal JOIN (vt JOIN processing ON vt.id = processing.vtId) ON personal.id = processing.personalId WHERE done = 0";
        public static string clientsQuery = query.select("name, fullname, email", "dle_users");


        public static string ordersQuery = "SELECT shopcart_vacushop.id, dle_users.fullname, amount, shopcart_vacushop.name, price, date, solved FROM shopcart_vacushop JOIN dle_users ON dle_users.user_id = shopcart_vacushop.userId";
        public static string providersQuery = "SELECT fullName, phone, email FROM providers";
        public static string deliveriesQuery = "SELECT deliveries.id, deliveries.date, providers.fullName, resource.name, deliveries.count, personal.firstName, deliveries.done FROM resource JOIN (providers JOIN deliveries ON providers.id = deliveries.providerId) ON resource.id = deliveries.resourceId JOIN personal ON personal.id = deliveries.personalId";
        public static string deliveryTable = "SELECT providers.fullName, resource.name, personal.firstName, count, date FROM deliveries JOIN providers ON providers.id = deliveries.providerId JOIN resource ON resource.id = deliveries.resourceId JOIN personal ON personal.id = deliveries.personalId WHERE done = 0";
        public static string productionQuery = "SELECT vt.mark, count, storages.name FROM vt_lots JOIN vt ON vt.id = vtId JOIN storages ON storages.id = storageId";
        /*Запросы на добавление*/
        public static string addPlan = "INSERT INTO processing (id, storageId, personalId, vtId, shift, date, count, plan, fact, done) VALUES ";
        public static string addDelivery = "INSERT INTO deliveries (id, providerId, resourceId, personalId, count, price, date, done) VALUES ";
        /*Получить количество всех марок ламп из бд*/
        public static string totalVtMarks = query.selectCountAll("marks_count", "vt");

        /*Получить количество всех видов ресурсов из бд*/
        public static string totalResourceTypes = "SELECT count(id) AS resource_count FROM resource";
        /*Получить число всех поставщиков из бд*/
        public static string totalProviders = "SELECT count(id) AS provider_count FROM providers";
        /*Получить число всех сотрудников, владеющих тех.процессом*/
        public static string totalProcessingPersonal = "SELECT id AS processing_personal FROM personal WHERE post = \"Радиотехник\" OR post = \"Инженер-Радиотехник\"";
        /*Получить число всех сотрудников, владеющих принципами складской деятельности*/
        public static string totalWarehousePersonal = "SELECT id AS warehouse_personal FROM personal WHERE post = \"Кладовщик\"";
        /*Бан*/
        public static string clientsBanReasonAndDays = "INSERT INTO dle_banned (id, users_id, descr, date, days, ip) VALUES ";
    }
}
