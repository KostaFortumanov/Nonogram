# Nonogram

## Опис на апликацијата
Нонограм е сликовита логичка загатка во која треба да ги обоиме полињата или да ги оставиме празни според броевите кои се наоѓаат на страните на полињата. Броевите ни покажуваат колку непрекинати линии на пополнети квадрати има во даден ред или колона. На пример, „4 8 3“ би значело дека има групи од четири, осум и три пополнети квадрати, по тој редослед, со барем еден празен квадрат помеѓу последователните групи. 

## Упатство за користење

### Почетен екран
На почетниот прозорец при стартување на апликацијата можеме да започнеме нова игра со клик на копчињата Easy, Medium и Hard со кои ни се отвараат нивоа со димензии 5x5, 10x10 и 15x15 соодветно, исто така можеме да го отвориме Solverot кои автоматски ни решава загатки по наше внесување на броевите.

<div align=center>
  <img src="https://github.com/KostaFortumanov/Nonogram/blob/master/Nonogram/Resources/title_page.jpg">
</div>

### Игра
По кликнување на Easy, Medium или Hard ни се отвараат соодветните нивоа. Со клик на копчињата Next Level/Previous Level може да се придвижуваме на следно/претходно ниво. Со клик на копчето Back се враќаме на почетниот екран. Полињата ги боиме со клик или клик и движење на маусот, ако полето на кое сме кликнале е точно ќе се обои сино, а ако е грешно ќе се исцрта X врз полето и ќе ни се намали бројот на срциња кои ги имаме, по 3 грешки треба да го започнеме нивото од почеток. Кога во еден ред/колона ќе ги пополниме сите полиња се тргаат броевите од од тој ред/колона, по пополнување на сите полиња ни се исцртува слика.

<img src="https://github.com/KostaFortumanov/Nonogram/blob/master/Nonogram/Resources/game.jpg">

### Solver
Во solverot имаме опција да одбираме од понудените димензии со клик на некое од radio копчињата. Потоа за секој ред/колона се внесуваат соодветните броеви одвоени со празно место. По внесување на сите броеви и притискање на копчето Solve на таблата ќе се исцрта решението. Ако не постои решение за дадените броеви се прикажува порака "No Solution".

<div align=center>
  <img src="https://github.com/KostaFortumanov/Nonogram/blob/master/Nonogram/Resources/solver.jpg">
</div>

## Претставување на проблемот

### Податоци
Главните податоци се чуваат во класата ```public class Game```.
```c#
public class Game {
        /// <summary>
        /// Листа од броевите за секој ред и колона
        /// </summary>
        List<string> nums;
        /// <summary>
        /// Листа од сите полиња
        /// </summary>
        List<Rectangle> rectangles;
        /// <summary>
        /// Широчина на едно поле
        /// </summary>
        float W;
        /// <summary>
        /// Висина на едно поле
        /// </summary>
        float H;
        /// <summary>
        /// Големина на таблата 5, 10 15
        /// </summary>
        int size;
        /// <summary>
        /// Дали класата ја користиме за играње или решавање
        /// </summary>
        bool solve;
        /// <summary>
        /// Име на сликата што ја добиваме на крај
        /// </summary>
        string name;
}
```
Во класата ```public class Rectangle``` ги чуваме податоците за секое поле.
```c#
    public class Rectangle {
        /// <summary>
        /// Положба на X координата
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Положба на Y координата
        /// </summary>
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        /// <summary>
        /// Каква боја треба да стане полето кога ќе ги пополниме сите полиња
        /// </summary>
        public Color RealColor { get; set; }
        /// <summary>
        /// Дали е точно
        /// </summary>
        public bool Correct { get; set; }
        /// <summary>
        /// Дали е стиснато
        /// </summary>
        public bool IsHit { get; set; }
        /// <summary>
        /// Дали играта е завршена
        /// </summary>
        public bool End { get; set; }
}
```
Нивоата ни се претставени како стрингови и содржат информации за името, броевите за секој ред/колона, бојата на секое поле во RGB формат и дали е точно или не полето.
```c#
level = "Lion,100 100,1 2,5,5,5,2,3,4,4,4,5,46 136 233 no,241 178 75 yes..."
```
Нивоата се поделени на easyLevels, mediumLevels и hardLevels во класата ```public class LevelPicker```.

### Алгоритми

#### Solver
Алгоритмот е exhaustive search и backtracking, што значи дека ги пробува сите можни комбинации ја проверува таблата и се враќа назад чим нема веќе валидни потези.
```c#
        private bool FindSolution(int i, int j) {
            if (i == height)
            {
                return true;
            }

            int nextI = i + (j + 1 == width ? 1 : 0);
            int nextJ = (j + 1) % width;

            // прво пробуваме дека е точно полето
            board[i, j] = true;
            if(verify(i, j) && FindSolution(nextI, nextJ))
            {
                return true;
            }

            // ако не е можно точно, пробуваме грешно
            board[i, j] = false;
            if (verify(i, j) && FindSolution(nextI, nextJ))
            {
                return true;
            }

            // ако не е можно и грешно завршуваме
            return false;
        }
```
Функцијата ```verify(i, j)``` проверува:
- дали потегот во полето е сè уште во ограничувањето на редот/колоната
- дали треба да се зголеми тековната група на линии
- дали треба да се намали тековната група на линии
- дали по завржување на редот/колоната барањата се исполнети

Алгоритмот на крај враќа матрица од логички променливи која и се предава на класата ```public class Game``` за да го исцрта решението.

#### Исцртување на слика
Кога сите полиња кои се точни се пополнети ја ставаме сликата во центарот и на секој 70ms ја зголемуваме или намалуваме за 10 секоја компонента на бојата(R, G, B) додека не стигнеме до вредноста на променливата ```RealColor```.
```c#
        public void ScaleColor() {
            int r = currentColor.R;
            int g = currentColor.G;
            int b = currentColor.B;

            if(r != RealColor.R)
            {
                if(r < RealColor.R)
                {
                    r += 10;
                } 
                else
                {
                    r -= 10;
                }
            }

            if (g != RealColor.G)
            {
                if (g < RealColor.G)
                {
                    g += 10;
                }
                else
                {
                    g -= 10;
                }
            }

            if (b != RealColor.B)
            {
                if (b < RealColor.B)
                {
                    b += 10;
                }
                else
                {
                    b -= 10;
                }
            }

            if(Math.Abs(r - RealColor.R) < 10)
            {
                r = RealColor.R;
            }

            if (Math.Abs(g - RealColor.G) < 10)
            {
                g = RealColor.G;
            }

            if (Math.Abs(b - RealColor.B) < 10)
            {
                b = RealColor.B;
            }

            currentColor = Color.FromArgb(r, g, b);
        }  
```

### GUI
Целата активност се случува на една форма и ја менуваме видливоста на комонентите кој ни требаат/не ни требаат.

пр.
``` c#
        private void TogglePlay()
        {
            btnEasyLvl.Visible = !btnEasyLvl.Visible;
            btnMediumLvl.Visible = !btnMediumLvl.Visible;
            btnHardLvl.Visible = !btnHardLvl.Visible;
            btnSolver.Visible = !btnSolver.Visible;
            btnNext.Visible = !btnNext.Visible;
            btnPrev.Visible = !btnPrev.Visible;
            btnBack.Visible = !btnBack.Visible;
            pbTitle.Visible = !pbTitle.Visible;
        }
```
