# 04-forms

This project has interesting material to work with forms in VueJS.

### 04.01 bootstrap-vue

Asuming we already have Vue CLI installed:

```
npm install -g @vue/cli
vue create <<project-name>>
cd project-name
```

This command will install bootstrap-vue in our project, including things like...
 - execute npm command
 - include ```import './plugins/bootstrap-vue'``` sentence in src/main.js
 - create new js file for this plugin

```
vue add bootstrap-vue
```

### 04.02 Binding

###### input

A good point to start with forms is to use ```v-model``` so we can use biderectional binding so we have a prop that always has the value entered in a field.

By default, v-model sync the input after input event, that means each key press updates the prop. Using v-model.lazy the sync is produces after change event, that means after the focus leave the field.

Assuming we have a prop object like this in the data(){} Vue function:
```javascript
userData: {
            email: '',
            password: '',
            age: 0
          }
```
```html
<input
    type="number"
    id="age"
    class="form-control"
    v-model.lazy="userData.age">
    <p> {{ userData.age }} </p> <!-- This will update when the focus leave the field -->
```

We can use ```v-model.trim``` to delete spaces and ```v-model.number``` to force convert the input into a number.

###### textarea

Interpolation doesn't work in textarea!
```html
<textarea
    id="message"
    rows="5"
    class="form-control"> {{ textAreaProp }}</textarea> <!-- Doen't work -->
```

Must use v-model for binding textarea:
```html
<textarea
    id="message"
    rows="5"
    class="form-control"
    v-model="textAreaProp"></textarea>
```

The textarea can store some spaces and different lines. The variable in v-model will store that lines, but if you want to visualize that you must use this CSS option:
```css
white-space: pre
```

###### checkbox

Imagine we have a group of checkboxes. We can store the values selected in an array that hold the checkboxes clicked this way.

First we have an array prop, that's the array that will be storing the checkboxes clicked. At the begining is empty:
```javascript
data(){
    return {
        // ...
          sendMailOptions:[]
        }
      }
```

Then, We can bind each checkbox with v-model to that array (the same object in each checkbox):
```html
<div class="form-group">
    <label for="sendmail">
            <input type="checkbox" id="sendmail"
                    value="SendMail"
                    v-model="sendMailOptions"> Send Mail
    </label>
    <label for="sendInfomail">
            <input type="checkbox" id="sendInfomail"
                    value="SendInfoMail"
                    v-model="sendMailOptions"> Send Infomail
    </label>
</div>
```

That's all, when a chekbox it's true, in the array will be inserted the value atributte of the checkbox (for our example 'SendMail' and 'SendInfoMail').

###### radiobutton

Creating a prop that will store the selected value in a group of radiobuttons:
```javascript
data(){
    return {
        // ...
          gender: ''
        }
      }
```

Assign that prop with v-model attribute. Important --> Doing this will Vue automatily recognize thats radiobutton as a group, so only will allow the user select once!
```html
<label for="male">
    <input type="radio" id="male"
        value="Male"
        v-model="gender"> Male
</label>
<label for="female">
    <input type="radio" id="female"
        value="Female"
        v-model="gender"> Female
</label>
```

###### Dorpdown

Important, the v-model atributte it's for select tag:
```html
<label for="priority">Priority</label>
<select id="priority" class="form-control"
            v-model="selectedPriority">
    <option v-for="item in prioritiesOptions" :value="item.key" :key="item.key"
            :selected="item.key == 'low'"> <!-- This only works if v-model dont have a default value -->                                
            {{ item.msg }}
    </option>
</select>
```

In this case the ```selectedPriority``` prop will store the selected value (not the complete object)

```html
<p>Priority: {{ selectedPriority }}</p>
```

###### Submit the form

The default behaviour for html forms is to submit the form to de server. But if we want to preserve the SPA effect (and not reload the page), we can stopt sending the data to the server adding the attribute ```@click.prevent``` and calling one of our methods:

```html
<button class="btn btn-primary"
    @click.prevent="SubmitTheForm"> <!-- This is a method in -->
    Submit!
</button>
```                    