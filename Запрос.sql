/*
Между таблицами "Продукты" (products) и "Категории" (categories) установлена связь типа "многие ко многим". Можно предположить, что сучществует таблица, в которой хранится свзяь "Продукты - Категории" (ProductsCategories). Тогда можно пострить следующий запрос:
*/
select
    p.name as product_name
  , c.name as category_name
from
    products_categories as pc
    full join
        products as p
        on
            pc.product_id = p.id
    full join
        categories as c
        on
            pc.category_id = c.id
order by
    p.name
  , c.name