[![Build Status](https://travis-ci.com/bo712/GameOfLife.svg?branch=master)](https://travis-ci.com/bo712/GameOfLife)

# GameOfLife
[Правила этой "игры"](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life) 

В описанные в википедии правила я внёс небольшое изменение для борьбы с патовыми ситуациями, когда расположение клеток на поле не позволяет игре продолжиться.
Таких ситуаций может быть две:
1. Правила игры не позволяют родиться новой клетке и умереть существующим.
Пример:

```
o o o o
o     o
o o o o 
```
В этом примере у каждой клетки по 2 соседа. Никакие клетки не умирают и не рождаются новые. На этом игра заходит в тупик.

2. Клекти рождаются и умирают, но, на самом деле, поле повторяется через поколение.
Пример:
```
поколение_N   поколение N+1   поколение N+2
     o                             o
     o            o o o            o
     o                             o
```
В этом примере центральная клетка будет жить, всегда имея двух соседей, а крайние клетки, имея в соседях лишь одну (центральную) клетку, будут погибать. Однако, перед смертью они будут давать жизнь двум другим клеткам (в примере выше в поколении N+1 рождаются левая и правая клетки).

*На самом деле, бывают случаи, когда цикл повторяется более, чем через одно поколение, но такие ситуации встречаются реже и их я не стал обрабатывать.*

В сучае появления патовых ситуаций на поле в случайном порядке помещается несколько дополнительных клеток, сдвигающих игру с мёртвой точки.
