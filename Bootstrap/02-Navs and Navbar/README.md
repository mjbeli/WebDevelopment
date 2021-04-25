# 02-Navs and Navbar

### 02.01 Nav

To create navigation elements we can use two different methods:
 - Use `ul` element.
 - Use `navs` in regular divs.

Using UL: creating `nav` class inside the UL element and put the `nav-item` in the list-item, then inside the link use the `nav-link` class in a `a` (anchor) element.
 
Using Navs: inside the div with `nav` class add `nav-item` for each element of the menu, then inside the link use the `nav-link` class in a `a` (anchor) element.

Basic sample:
```html
<nav class="nav">
    <a href="#" class="nav-item nav-link">Link 1</a>
    <a href="#" class="nav-item nav-link">Link 2</a>
    <a href="#" class="nav-item nav-link">Link 3</a>
    <a href="#" class="nav-item nav-link">Link 4</a>
    <a href="#" class="nav-item nav-link">Link 5</a>
    <a href="#" class="nav-item nav-link">Link 6</a>
</nav>
```

```html
<ul class="nav">
    <li class="nav-item"><a href="#" class="nav-link">Link 1</a></li>
    <li class="nav-item"><a href="#" class="nav-link">Link 2</a></li>
    <li class="nav-item"><a href="#" class="nav-link">Link 3</a></li>
    <li class="nav-item"><a href="#" class="nav-link">Link 4</a></li>
    <li class="nav-item"><a href="#" class="nav-link">Link 5</a></li>
    <li class="nav-item"><a href="#" class="nav-link">Link 6</a></li>
</ul>
```
![img1](./img/basicNav.JPG)


#### 02.01.01 Nav-link options
With the `nav-link` class you can use classes: 
 - `active`: show the link as active (only modify the appareance if the `nav` element has a style associated, see below)
 - `disable`: show the link as disable and the user can't click on it.

#### 02.01.02 Nav styles
With the `nav` class can use this options:
 - `nav-pills`: appears like little buttons with rounded edges
 - `nav-tabs`: appears like tabs.

Remember active need to nav element has defined an style.

```html
<ul class="nav nav-pills">
    <li class="nav-item"><a href="#" class="nav-link active">Link 1</a></li>
    <li class="nav-item"><a href="#" class="nav-link">Link 2</a></li>
    <li class="nav-item"><a href="#" class="nav-link disabled">Link 3</a></li>
</ul>
```
```html
<nav class="nav nav-pills">
    <a href="#" class="nav-item nav-link active">Link 1</a>
    <a href="#" class="nav-item nav-link">Link 2</a>
    <a href="#" class="nav-item nav-link disabled">Link 3</a>
</nav>
```
![img2](./img/NavPills.JPG)

```html
<ul class="nav nav-tabs">
    <li class="nav-item"><a href="#" class="nav-link active">Link 1</a></li>
    <li class="nav-item"><a href="#" class="nav-link">Link 2</a></li>
    <li class="nav-item"><a href="#" class="nav-link disabled">Link 3</a></li>
</ul>
```
![img3](./img/NavTabs.JPG)


#### 02.01.03 Nav alignment
Can use flexbox classes to align the nav:
 - `justify-content-center`
 - `justify-content-end`: right align the nav content
 - `nav-fills`: want the links take the entire width of the container (The space of each link is going to be different depending on the width content/text).
 - `nav-justified`: force the space between each element to be the same, no matter the length of the text.
 - `flex-columns`: make the navigation more reponsive.

```html
<nav class="nav nav-pills nav-fill">
    <a href="#" class="nav-item nav-link active">Link 1</a>
    <a href="#" class="nav-item nav-link">Link 2 gthyfhthrgtgtgtgggt</a>
    <a href="#" class="nav-item nav-link disabled">Link 3</a>
    <a href="#" class="nav-item nav-link">Link 4</a>
    <a href="#" class="nav-item nav-link">Link 5</a>
    <a href="#" class="nav-item nav-link">Link 6</a>
</nav>
```

![img4](./img/NavPillsAlignmentFill.JPG)


```html
<nav class="nav nav-pills nav-fill">
    <a href="#" class="nav-item nav-link active">Link 1</a>
    <a href="#" class="nav-item nav-link">Link 2 gthyfhthrgtgtgtgggt</a>
    <a href="#" class="nav-item nav-link disabled">Link 3</a>
    <a href="#" class="nav-item nav-link">Link 4</a>
    <a href="#" class="nav-item nav-link">Link 5</a>
    <a href="#" class="nav-item nav-link">Link 6</a>
</nav>
```
![img5](./img/NavPillsAlignmentJustify.JPG)


In the nex sample, the menu will be viewed as a row from sizes greater than sm:
```html
<nav class="nav nav-pills flex-column flex-sm-row">
    <a href="#" class="nav-item nav-link active">Link 1</a>
    <a href="#" class="nav-item nav-link">Link 2 gthyfhthrgtgtgtgggt</a>
    <a href="#" class="nav-item nav-link disabled">Link 3</a>
    <a href="#" class="nav-item nav-link">Link 4</a>
    <a href="#" class="nav-item nav-link">Link 5</a>
    <a href="#" class="nav-item nav-link">Link 6</a>
</nav>
```
![img6](./img/NavFlexColumn.JPG)


 ### 02.02 Navbar

#### 02.02.01 Navbar classes
`navbar` class goes on the main container, by deafult the elements inside will stack (top one on another) so we need to add `navbar-expand-SIZE` to control when the navbar is going to expand (go to horizontal).

#### 02.02.02 Navbar colors

In the same container thar uses `navbar`, use `bg-COL` to specify the color of the navbar. With COL: primary, secondary, success, danger, warning, info, light, dark or white.

Another 2 classes to specify the color background are: `navbar-light`, `navbar-dark`

Note that if we define the light background with  it's good to define the navigation elements with `navbar-light` in order to see the navigation with contrast and if we define `bg-dark` it's good to use `navbar-dark`.

```html
<nav class="navbar bg-light navbar-light">
    <!-- Container for navigation links -->
    <div class="navbar-nav">
        <a href="#" class="nav-item nav-link active">Link 1</a>
        <a href="#" class="nav-item nav-link">Link 2</a>
        <a href="#" class="nav-item nav-link disabled">Link 3</a>
        <a href="#" class="nav-item nav-link">Link 4</a>
    </div>
</nav>
```
![img6](./img/navbarnavBasic.JPG)

An example with expand:
```html
<nav class="navbar bg-dark navbar-dark navbar-expand-sm">
    <!-- Container for navigation links -->
    <div class="navbar-nav">
        <a href="#" class="nav-item nav-link active">Link 1</a>
        <a href="#" class="nav-item nav-link">Link 2</a>
        <a href="#" class="nav-item nav-link disabled">Link 3</a>
        <a href="#" class="nav-item nav-link">Link 4</a>
    </div>
</nav>
```
![img7](./img/navbarnavExpand.JPG)

Note that if we define the light background with  it's good to define the navigation elements with `navbar-light` in order to see the navigation with contrast and if we define `bg-dark` it's good to use `navbar-dark`.

#### 02.02.03 Navbar-nav options

Inside the `navbar` class we need to use the class `navbar-nav` in another container. This is where the main navigation will go. Inside the `navbar-nav` container we'll need to have `nav-item` and `nav-link` elements. 

If we are using list to declare the menu, we'll need to use `nav-item` in the `li` element and `nav-link` in the anchor element.

If we only use anchors (as we see in the examples), we'll use `nav-item` and `nav-link` both in the anchor element.

With the `nav-link` class you can use classes: 
 - `active`: to indicate for example, the page where are.
 - `disable`: show the link as disable and the user can't click on it.

#### 02.02.04 Brand and text

`navbar-brand` is the classes when you want to add some logo or text usually in a headline. Also you can add `navbar-text` to add text in the headline.

```html
<nav class="navbar bg-dark navbar-dark navbar-expand-sm">
    <a href="#" class="navbar-brand">MyCompanyName</a>
    <!-- Also can use an image like:
        <a href="#" class="navbar-brand"> <img src="...."> </a>
    -->
    <div class="navbar-nav">
        <a href="#" class="nav-item nav-link active">Link 1</a>
        <a href="#" class="nav-item nav-link">Link 2</a>
        <a href="#" class="nav-item nav-link disabled">Link 3</a>
        <a href="#" class="nav-item nav-link">Link 4</a>
    </div>
    <span class="navbar-text">Descripter text</span>
</nav>
```
![img8](./img/navbarBrand.JPG)













