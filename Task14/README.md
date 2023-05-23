﻿# Задача №14: имя в рамке
Вывести имя в прямоугольник из символа, который введет сам пользователь.

Вы запрашиваете имя, после запрашиваете символ, а после отрисовываете в консоль его имя в прямоугольнике из его символов.

Пример:

```
Введите имя: Alexey
```
```
Введите символ: %
```

```
%%%%%%%%%%
% Alexey %
%%%%%%%%%%
```

Примечание:

Длину строки можно всегда узнать через свойство `Length`:
```csharp
string someString = "Hello";

Console.WriteLine(someString.Length); // 5
```

## Build

Build:
```
dotnet build
```

Just run:
```
dotnet run --project src\App.csproj
```