# игра про кибер безопасность. 

## Уровень 1
В игре пока - что тока 1 уровень.\
Его оснавная суть ***исследование вредоносного трафика***\
Каждый раз генерируются рандомное количсвваое вредоносного подключения. Это может быть как одно так и 5 (min | max)\
Генерируется список по к которым првязаны данные ip. По ним как раз и нужно орентироватся.\
На данный момент не добавил протокол и пользователя.
Если не выполнить задание за 15 минут то игра заканчивается.
Но если найти все подключения (даже если затронуть обычные) то игра автомотички закончится и перейдёт к подсчёту итогов.
Коонечный бал за уровень зависит от точности выполнения.\
Если дропнуть обычных (безопасный) коннект то это будет минус но не большой\ 
Чем больше обычных (безопасный) коннектов дропнуто тем меньше бал и больше наказание за ошибку.\

##Запуск готового решения
Что - бы сразу запустить игру нужно скачать всё решение либо только папку Buid (build)
распаковать тока Buid (build) в какую-то папку и запустить game-about-cybersecurity.exe

##Компиляция
Игра использует технологию il2cpp для улучшения производительности + для защищённости кода от прямого редактирования.
Что бы компиляция прошла успешно нужно в unity установить модуль il2cpp для windows
https://imgur.com/a/JccgDFr 
Если не работает il2cpp то в настройках проекта можно выставить mono (потеряется скорость + код будет открыт для редактирования)
https://imgur.com/a/z2FPw1y
