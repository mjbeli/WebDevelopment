# 04-Layout Components

### 04.01 Jumbotron

Used to give a highlight to a section, commonly used at the top of the site.

Give to the principal container the class `jumbotron`. Using the class `jumbotron-fluid` takes the entire space of the parent and erase the rounded corners.

Note: for align content inside, you need to add an aditional container and add aditional styles to it.

Different exampls of jumbotron disposition

```html
<div class="container mt-2">
    <div class="jumbotron">
        <h5>Jumbotron</h5>
        This is my jumbotron acting like a header of the page
    </div>
</div>
```
![img1](./img/Jumbotron1.jpg)


```html
<div class="jumbotron jumbotron-fluid">
    <div class="container">
        <h5>Jumbotron</h5>
        This is my jumbotron acting like a header of the page, note that this one occupies all the space in parent and the coners aren`t rounded
    </div>
</div>
```
![img2](./img/Jumbotron2.jpg)


### 04.02 Table styles

To give some styles to a table, add the class `table` to the table html element itself. 
Aditionally, there are a number of classes that can be added to the basic table class, so the look can change:
 - `table-dark` gives a dark background and light text to the table.
 - `table-striped` changes color background for the rows in the table.
 - `table-bordered` put a border around the entire table.
 - `table-borderless` delete the underlines borders.
 - `table-hover` changes the color of the rows when hover with mouse.

Add colors in the header of the table with:
 - `thead-light`
 - `thead-dark`

Changes the color of all tr and td with `table-COL` active, primary, secondary, success, danger, warning, info, light, dark.

To change the color of tr and td but using more dark colors use `bg-COL` primary, success, danger, warning, info.

To mosify the text color use `text-COL` primary, secondary, success, danger, warning, info, light, dark.

Adding this classes to the table html element will control the size of the table:
 - `table-sm`
 - `talbe-responsive-SIZE` sm, md, lg, xl

```html
<table class="table table-striped table-hover table-bordered table-responsive">
    <thead class="thead-dark">
        <tr>
            <th scope="col">Item #</th>
            <th scope="col">Product or Service</th>
            <th scope="col">Price (ea.)</th>
            <th scope="col">Retail Price (Case)</th>
        </tr>
    </thead>
    <tbody>
        <tr class="bg-info text-dark">
            <th scope="row">100050</th>
            <td>Advance Pet Oral Care Toothbrush and Toothpaste</td>
            <td>$9.55 </td>
            <td>$108.87</td>
        </tr>
        <tr>
            <th scope="row">100043</th>
            <td>Basic Teeth Cleaning and Exam</td>
            <td>$100.00 </td>
            <td>$1,140.00</td>
        </tr>
        <tr>
            <th scope="row">100013</th>
            <td class="table-success">Calm Cat Anxiety Relief Spray</td>
            <td>$9.49 </td>
            <td>$108.19</td>
        </tr>
    </tbody>
</table>
```

![img3](./img/Table.JPG)


### 04.03 Cards Layout

Create a container that has a card layout.

##### 04.03.01 Cards basics

Asign to the main container the class `card`. Inside of that container we must have another container with the class `card-body`.

Inside the card-body we gonna have a series of classes that will identify the type of content.
`card-text`, `card-title`, `card-subtitle`, `card-link`, `card-img`. Theses classes give the content the proper alignment.

We can use the traditional classes for backgrounds, border and text: bg-COL, border-COL, text-COL.

