﻿# Задача №44: конфигуратор пассажирских поездов
У вас есть программа, которая помогает пользователю составить план поезда.

Есть 4 основных шага в создании плана:
* Создать направление — создает направление для поезда (к примеру, Бийск—Барнаул)
* Продать билеты — вы получаете случайное кол-во пассажиров, которые купили билеты на это направление
* Сформировать поезд — вы создаете поезд и добавляете ему столько вагонов (вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
* Отправить поезд — вы отправляете поезд, после чего можете снова создать направление.

В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии.

## Build

Build:
```
dotnet build
```

Just run:
```
dotnet run --project src\App.csproj
```
