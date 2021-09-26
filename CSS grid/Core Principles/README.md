# 01-Core Principles

### 01.01 Define a grid

By default, the basic grid only contains 1 cell (1 row and 1 column), which will contain all the grid items inside. So this code apparently do nothing at all:

```html
<div class="gridContainer">
  <!-- Content here -->
</div>
```

```css
.gridContainer {
    display: grid
}
```

The properties `grid-template-rows` and `grid-template-columns` let us to define grid lines and columns of the grid continer. Both properties receive a list of values separated by spaces that set the row/column width and height. The values defines the distance between  one line and the next one.


This sample defines 2 column grid, each column has 50% of the space of the grid:
```css
.gridContainer {
    display: grid;
    grid-template-columns: 50% 50%; 
}
/* 
  Find the first column grid line (number 1), 
  then put a secong grid line (number 2) at the 50% of the container 
  and put the another grid line (number 3) after the remaining 50% 
  */
```

![FirstGrid](assets/FirstGrid.png?raw=true)


The default width of any row or column is "auto", you can use that value if you want the cell expand or contract automatically depending on the content.

### 01.02 Units

You can mix differents measures in the list, like px, em %, vw, ...

For example:
```css
.gridContainer {
    display: grid;
    grid-template-columns: 10px 4em 20% 50vw; 
}
```

CSS grid has aditional measures units

##### 01.02.01 Fractions

Fraction units (fr): represents a fraction of the available space in the grid.

This is the same as `grid-template-columns: 50% 50%;`. This means that each column has 1 fraction of the space in the grid, so this means that each column has 50% of space.
```css
.gridContainer {
    display: grid;
    grid-template-columns: 1fr 1fr; 
}
```

So to define a grid with column 1 25%, column 2 25% and column 3 50%:

```css
.gridContainerFractions {
    display: grid;
    grid-template-columns: 1fr 1fr 2fr;
}
```

![FirstGrid](assets/UnitFractions.png?raw=true)


Can alternate differents units with fractions like `grid-template-columns: 50em 1fr 1fr;`

##### 01.02.02 Min max function

Defines a size range greater or equal to min value and lower or equal than max value. Allows us to create responsive layouts.

In this same, the first column will expand or reduce automatically, the same as the second column, but with a max width of 20em and min of 10em.
```css
.gridContainerMinMax {
    display: grid;
    grid-template-columns: 1fr minmax(10em, 20em);
}
```

### 01.03 Repeat

Repeat is a way to define multiple columns in a short way. Repeat the given pattern a number of times. 
So `grid-template-rows: repeat(2, 1fr) 2fr;` repeat `1fr` 2 times.

Can put more complex expressions to define the pattern to repeat.

```css
.gridContainerRepeat {
    display: grid;
    grid-template-columns: repeat(4, 1fr 4em);
}
```

Note: important not put a space afet `repeat` key word

![FirstGrid](assets/Repeat.png?raw=true)



### 01.04 Manual placement

By default the items of the grid will populate it form top-left to bottom-right. But you can also define manually where to put items in the grid.

You can declare the grid column and grid row for each item:

```css
.gridSampleManuallyItemPosition {
    display: grid;
    grid-template-columns: 2fr repeat(2, 1fr);
    grid-template-rows: auto 1fr 3fr;
}

.mastheadManualPosition {
    /* item will be placed in column between 2 and 4 and in row between 2 and 3 */
    grid-column: 2/4;
    grid-row: 2/3;
}
```

Item `mastheadManualPosition` it's positioned in columns 2 and 3 (from column line 2 to column line 4) and in row 2 (from row line 2 to row line 3).

![FirstGrid](assets/ItemGridManualPosition.png?raw=true)

Note than the others grid items will be repositioning to fit in the available space (thats means starting top-left).


### 01.05 Implicit lines

If grid items placement takes additional columns or rows to be created, the browser adds implicit lines to keep de structure of the grid.
The grid only has 3 rows define but the `main-content-implicit-line` has defined the row line 4 (the last row line) so the element its placed in the fourth row:

```css
.gridImplicitLines {
    display: grid;
    grid-template-columns: 2fr repeat(2, 1fr);
    grid-template-rows: auto 1fr 3fr;
}

.main-content-implicit-line {
    grid-column: 1/4;
    grid-row: 4;
}
```
![FirstGrid](assets/ImplicitLines.png?raw=true)

The height of the new row is ´auto´ because it is not explicit define.

Also we can just define the numbers of cells we want the item expand using ´span´ keyword
```css
.main-content-implicit-line {
    grid-column: 1 span;
    grid-row: 4;
}
```

![FirstGrid](assets/span.png?raw=true)


### 01.06 Grid areas

```html
<div class="gridAreas">
    <div class="masthead-gridarea"> <h1>class masthead-gridarea</h1> </div>
    <div class="page-title-gridarea"> <h1>class page-title-gridarea</h1> </div>
    <div class="main-content-gridarea"> <h1>class main-content-gridarea</h1> </div>
    <div class="sidebar-gridarea"> <h1>class sidebar-gridarea</h1> </div>
    <div class="footer-content-gridarea"> <h1>class footer-content-gridarea</h1> </div>                
</div>
```

Using 'grid-template-areas' inside the grid container we can define rectangular areas within the grid and give it names (this areas, of course, can span one or more cells). Then we can use those names inside the grid items and the property `grid-area` to place items. We can turn the grid into a map! 

Imagine our rid it's defined like this:
```css
.gridAreas {
    display: grid;
    grid-template-columns: 2fr 1fr 1fr;
    grid-template-rows: auto 1fr 3fr;

    grid-template-areas: "title title title" /* row 1 */
    "main masthead masthead"                 /* row 2 */
    "main sidebar footer"                    /* row 3 */
    ;
}
```

Note that `grid-template-areas` define each cell with a name. Now using "show area names" in the developer tools we can see the assigned name for each cell.

![firstGridArea](assets/firstGridArea.png?raw=true)

Now we can use that names defined in each cell and assign them to our css elements like this:

```css
.masthead-gridarea { grid-area: masthead; }

.page-title-gridarea { grid-area: title; }

.main-content-gridarea { grid-area: main; }

.sidebar-gridarea { grid-area: sidebar; }

.footer-content-gridarea { grid-area: footer; }
```

##### 01.06.01 Empty areas inside grid areas

To set an empty area inside the map of the grid area, just use a dot like name area.

In this case we have an empty cell inside in the middle of the second row.
```css
.gridAreas {
    display: grid;
    grid-template-columns: 2fr 1fr 1fr;
    grid-template-rows: auto 1fr 3fr;

    grid-template-areas: "title title title" /* row 1 */
    "main . masthead"                        /* row 2 */
    "main sidebar footer"                    /* row 3 */
    ;
}
```
![GridArea](assets/EmptyCellGridArea.png?raw=true)

### 01.07 Responsive

##### 01.07.01 Grid area responsive using media queries

We use media queries to create responsive grid like this:

```css
/* This will apply bellow 600px */
.gridAreasResponsive {
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-template-rows: auto 1fr 3fr;
    grid-template-areas: "title title" "main main" "footer footer";
}


/* This will apply for 600px or more */
@media screen and (min-witdh: 600px) {
    .gridAreasResponsive {
        grid-template-columns: 2fr 1fr 1fr;
        grid-template-areas: "title title title" "main masthead masthead" "main sidebar footer";
    }
}
```
![GridAreaResponsive](assets/GridAreaResponsive.png?raw=true)

##### 01.07.02 Responsive with no media queries

To avoid using media queries we can combine the `repeat` and the `minmax` functions like this:

```css
.responsiveGrid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
}

.masthead-resp {
    background-color: #b46ae3;
    width: 300px; /* this is necessary */
}
```

`minmax(300px, 1fr)` requires the width of each grid item to always be in between 300px and 1fr.

If their widths is bellow to 300px, a new row will form. This is thanks solely to auto-fit. Basically, `auto-fit` tracks the widths of each container: if the width of a container falls below 300px, auto-fit will form a new row.


![responsiveNoMedias](assets/responsiveNoMedias.png?raw=true)



