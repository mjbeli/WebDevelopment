# 01-Layout

### 01.01 Basics

In order to work with layout in bootstrap you must use 3 main classes:
 - container
 - row
 - column

#### 01.01.01  Container

You can define container with a size like this:

```container-(size)```

Where size can be: sm, md, lg, xl, fluid

All containers add 15px of padding in both sides left and rigth. When adding rows and columns, that padding will de ignore (column will be 30px of padding but that's another history).

```html
<div class="container">
  <!-- Content here -->
</div>
```

```.container``` and ```.container-sm``` 100% of width if screen is < 576px.
```.container-md``` 100% of width until 768px.
```.container-lg``` 100% of width until 992px.
```.container-xl``` 100% of width until 1140px.
```.container-fluid``` always will fill with 100% of width.

#### 01.01.02  Row & Col

row class inside a container.   
By default, create a row inside a container with -15px each side, left and right and col are created with a padding of. Adding `no-glutters` delete that margin and the columns padding.

Sample of a grid with row and col (note that the padding inside each column it's been ignored and the margin of the rows are being applied due to no-glutters):
```html
    <div class="container-fluid">
        Rows & col with no-glutters
        <div class="row no-gutters border border-primary">
            <div class="col-2 border border-secondary">
                Colum
            </div>
            <div class="col-2 border border-secondary">
                Colum
            </div>
            <div class="col-2 border border-secondary">
                Colum
            </div>
        </div>
    </div>
```
![img1](./img/RowCol-noglutters.JPG)

When we don't use `no-glutters`, the margin of the rows are ignored and the apdding of the columns are appplied:
![img2](./img/RowCol-normal.JPG)


We can use `row row-cols-N` to fit in each row N columns at maximun, here an example to fit 2 columns in each row (note that in this case the col class doesn't have the numbers):
```html
    <div class="container-fluid">
        <div class="row row-cols-2 no-gutters border border-primary">
            <div class="col border border-secondary">
                Colum1
            </div>
            <div class="col border border-secondary">
                Colum2
            </div>
            <div class="col border border-secondary">
                Colum3
            </div>
            <div class="col border border-secondary">
                Colum4
            </div>
            <div class="col border border-secondary">
                Colum5
            </div>
        </div>
    </div>
```
![img2](./img/rowcol2.JPG)