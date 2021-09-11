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
    grid-template-columns: 50% 50%; /* Find the first column grid line, then put a secong grid line at the 50% of the container and put the */
}
```
