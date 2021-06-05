# 06-Interactive Components

### 06.01 Tooltips

Only use tooltips in html elements that are focusable like links, buttons or form buttons.


To setup the tooltip add `data-toggle="tooltip"` attribute to the html element and then add the `title` attribute with some text in it.

Tooltip can be configurable in 2 ways, you can use `data` attribute (it's a lot easier and is waht we are using here) or JavaScript configuration. Even using `data` attribute, by default tooltips are not enabled, so for enabling it you must use JavaScript activation.


Options can use in tooltip (alls are attributes of html elements):
 - data-placement: top, right, bottom, left.
 - data-trigger: hover (by default), click, focus.
 - data-html: true, false. 

This is for enable tooltips with jQuery
```html
<html lang="en">
    <head>
        ...
    </head>

    <body>
        ...
    </body>

    <script>
        $(function() {
            $('[data-toggle="tooltip"]').tooltip(); // this function can receive options object.
        });
    </script>
</html>
```

Using the tooltip
```html
<div class="container-fluid mb-2">
    <p>
    Lorem ipsum dolor sit amet, consectetur adipiscing elit. <a href="#" data-toggle="tooltip" data-placement="left" title="This is my tooltip">Phasellus dapibus</a> convallis nisi a commodo. Praesent vitae rhoncus lectus, a ornare neque. Duis ut metus molestie, accumsan neque non, rhoncus augue.
    </p>
</div>
```

![img1](./img/Tooltip1.JPG)

### 06.02 PopOvers

Let's us display aditional content triggered by events like click. There're very similar to tooltips, but they have different styles.

To setup, simply use attribute `data-toggle="popover"` in the html element and then add `title` attribute with the text you want to show. Also use `data-content="content"` to add aditional content (the title will be the headline and the content fill be some sort of sub-content).

In order to activate or enabling you have to do in a similiar way of tooltips.

Options can use in tooltip (alls are attributes of html elements):
 - data-placement: top, right, bottom, left.
 - data-trigger: hover, click (by default), focus.
 - data-container: defines the container the popover will be attached to.

```html
<html lang="en">
    <head>
        ...
    </head>

    <body>
        ...
    </body>

    <script>
        $(function() {
            $('[data-toggle="popover"]').popover(); // this function can receive options object.
        });
    </script>
</html>
```

```html
<div class="container-fluid mb-3">
    <button class="btn btn-info" data-toggle="popover" title="Info" data-content="Some more deatiled info" data-placement="bottom">
        More Info
    </button>
</div>
```

![img2](./img/PopOvers1.JPG)