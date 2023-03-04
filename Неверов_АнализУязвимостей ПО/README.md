### Web Server Учёта итоговых оценок в школе

## Реализованный функционал
1) Ручной ввод Классов Учеников Учителей
2) Пакетный ввод Классов 
3) Пакетный ввод Учеников с возможностью перевода в новый класс без сохранения преемственности 
4Не допускается физическое удаление записей об учениках

## Структура и технологии проекта

* **Проект построен на Asp Net Core(Net7.0) Blazor Web pages**
  [Net 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* /Models - модели классов DTO объектов и БД схемы 
* /Pages - представление Web страниц + с# code
* **СУБД** - [PGSQL Server 14.0](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)
* **ORM** - Entity Framework Core

## Схема БД
![DB Schema.jpg](wwwroot%2FDB%20Schema.jpg)

## Процесс запуска
1)Установка PGSQL 14.0
2)Установка RunTime .Net Core 7.0.
3)Запуск проекта из папки ../Неверов_АнализУязвимостей ПО\Неверов_АнализУязвимостей ПО\bin\Release
