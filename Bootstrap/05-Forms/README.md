# 05-Forms

### 05.01 Basics


The basic way to create a form an group elements is to use `form` class. This class can be applied to any block element like divs add a little spacing at the bottom of the element. 

Important --> applies to the group a display block, forms will by default stack vertically.

Another two classes you can use for input basic text
 - `form-group`: add basic structure to the form that groups labels, controls, optional help text, validationg messaging...
 - `form-text`: for help text below inputs (display block and add some top margin)
 - `form-control`: for basic text input fields (inputs, select and text-areas).
 - `form-control-label`: labels inside form-group (important to form validation later!)
 - `form-control-file`: for file inputs.

```html
<h5>Simple form</h5>
<div class="container mb-2">
    <form>
        <div class="form-group">
            <label class="form-control-label" for="inputtext">Example label</label>
            <input type="text" class="form-control" id="inputtext" placeholder="Example input">
            <small id="helper" class="form-text text-muted">
                Help message text.
            </small>
        </div>
        <div class="form-group">
            <label class="form-control-label" for="selectType">Select type</label>
            <select class="form-control" id="selectType">
                <option value="cat">Cat</option>
                <option value="dog">dog</option>
            </select>
        </div>
        <div class="form-group">
            <label class="form-control-label" for="areatext">Select type</label>
            <textarea class="form-control" id="areatext" cols="30" rows="5"></textarea>
        </div>
    </form>
</div>
```
![img1](./img/form1.JPG)
