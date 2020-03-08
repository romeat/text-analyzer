### Поиск самых часто встречающихся триплетов в тексте

Консольное приложение, позволяющее найти и вывести на экран десять самых часто встречающихся триплетов в тексте входного файла.  
Входной параметр приложения - путь к текстовому файлу. Путь может задаваться в виде аргумента командной строки, либо вводиться пользователем.  
Выходные параметры - строка с десятью самыми встречающимися триплетами и время работы программы.  

Обработка файла может быть отменена нажатием на любую клавишу. В этом случае на экран будет выведен текущий результат.  

Библиотека обработчика текста находится в проекте TextAnalyzer. Для обработки текста создается экземпляр обработчика:  
` var engine = new Engine();`  

и вызывается метод GetTriplets(), принимающий путь к файлу, токен CancellationToken для возможности прервать обработку файла, и возвращающий список из десяти самых частых триплетов в убывающем порядке:  
` var result = engine.GetTriplets("path\to\your\file", token);`  

Особенности работы:  
1) триплеты, встречающиеся с одинаковой частотой, никак не сортируются. Если, например, десятое место по количеству присутствия в тексте делят триплеты "abc" и "xyz", то в возвращаемый результат может попасть любой из них;  
2) если в тексте менее десяти разных триплетов, то будет возвращен список меньшей длины;  
3) обработка входного файла идет в многопоточном режиме с помощью шаблона Producer-Consumer.
