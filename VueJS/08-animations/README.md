# 08-animations

### 08.01 Transitions Setup

```html
<transition></transition>
```
It's a tag that provides vue and animate the element inside the tag. We can have several elements inside transition
 tg (so we can animate the change betwwen them) but only of them can be show at a time. 

We can't animate a list. 

We can have several div but they have to be exclude between them with v-if or similar.

In addition to the transition tag, we need also to add some CSS classes. Vue automatically attach the transition tag to two CSS class. Filling that 2 class will animate the element when gets visible and when gets hide.

The transitions in Vue works tipically with v-if v-show, dynamic components and other utilities we'll see...

If the transition has a name CSS classes are attached adding some sufix to that name. The CSS class when adding the element to the DOM are:
 - ```-enter```: this is the starting point
 - ```-enter-active```: this is the CSS attached until the animation finishes and where the final state is setup.

 When the element it's removed from the DOM the CSS classes are:
  - ```*-leave```:
  - ```*-leave-active```: duration and final state.

  If the transition hasn't a name the default names are v-enter, v-enter-active, v-leave and v-leave-active.

```html
<transition name="fade"> <!-- Vue will attach CSS classes: fade-enter, fade-enter-active, fade-leave & fade-leave-active -->
    <dir class="alert alert-info" v-if="show">This is some info</dir>
</transition>
```

Vue will analyze the CSS classes to determine how long will be the animations:

> Inside <style scoped>

```CSS    
.fade-enter { /* Enter the DOM: CSS attached for frame one at the beginning, setting a transition here will not work */
    opacity: 0;
}
```

Maybe you will be tempted to put here the destiny value of opacity. Wrong! remember the opacity 0 only it's determined for the first frame, after the first frame all this CSS class will be applied, so putting here 1 will pass directly from 0 to 1 with no apparent transition.

```CSS    
.fade-enter-active { /* Enter the DOM: CSS attached for the whole element at animation time */
    transition: opacity 1s;
    /* opacity: 1  --> Wrong! */ 
}
```
opacity: 1; --> This is the default value, so we don't need to specify it
```CSS    
.fade-leave { /* Leave the DOM: CSS attached for one frame at the beginning */
}
```
Here we are telling to change opacity during 1 sec. until the opacity value will be 0
```CSS    
.fade-leave-active { /* Leave the DOM: CSS attached for the whole element at animation time */
    transition: opacity 1s; /* duration */
    opacity: 0;             /* destiny value for opacity */
}
```
