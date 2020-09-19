# 08-animations

### 08.01 Basics setup

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
 - ```*-enter```: this is the starting point
 - ```*-enter-active```: this is the CSS attached until the animation finishes and where the final state is setup.

 When the element it's removed from the DOM the CSS classes are:
  - ```*-leave```:
  - ```*-leave-active```: duration and final state.

If the transition hasn't a name the default names are v-enter, v-enter-active, v-leave and v-leave-active.

We can explicit indicate the CSS classes we want to use in a transition tag by using this attributes:

```html
<transition enter-class="v-enter"
            enter-active-class="v-enter-active"
            leave-class="v-leave"
            leave-active-class="v-leave-active"> 
    <div class="alert alert-info" v-if="show">This is some info</div>
</transition>
```

*Important:* If you want to leave unspecified a class, don't leave it empty, just erase the entire attribute.
Note: It seems that appear attribute (see abowe) doens't work with this 4 attributes.

### 08.02 CSS Transitions

```html
<transition name="fade"> <!-- Vue will attach CSS classes: fade-enter, fade-enter-active, fade-leave & fade-leave-active -->
    <div class="alert alert-info" v-if="show">This is some info</div>
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

### 08.03 CSS Animations

Animations in Vue are very similar to transitions:

```html
<transition name="slide"> <!-- Vue will attach CSS classes: fade-enter, fade-enter-active, fade-leave & fade-leave-active -->
    <div class="alert alert-info" v-if="show">This is some info</div>
</transition>
```

```CSS    
.slide-enter {
    /* transform: translateY(30px); This it's not necessary because it's defined in keyframe animation */
}
.slide-enter-active { 
    animation: slide-in 1s ease-out forwards; /* slide-in is the name of keyframe animation */
}
.slide-leave { 
    /* again it's not necessary because the stating position it's defined in keyframe animation */
}
.slide-leave-active { 
    animation: slide-out 1s ease-out forwards;
}

@keyframes slide-in {
    from {
        transform: translateY(30px); /* Start of the animation: +30px in Y axis (vertical) */
    }
    to {
        transform: translateY(0); /* End of the animation, the real position defined for the element in our document */
    }
}

@keyframes slide-out {
    from {
        transform: translateY(0); /* Start of the animation, the real position defined for the element in our document */
    }
    to {
        transform: translateY(30px); /* End of the animation: +30px in Y axis (vertical) */            
    }
}
```

### 08.04 CSS Transitions & Animations together


```CSS
.slide-enter { 
    opacity: 0;
}

.slide-enter-active {
    animation: slide-in 1s ease-out forwards; /* slide-in is the name of keyframe animation */
    transition: opacity .5s;
}

.slide-leave { }

.slide-leave-active { 
    animation: slide-out 1s ease-out forwards;
    transition: opacity 1s;
    opacity: 0;
}

@keyframes slide-in {
    from { transform: translateY(30px); }
    to { transform: translateY(0); }
}

@keyframes slide-out {
    from { transform: translateY(0); }
    to { transform: translateY(30px); }
}
```

In case we have 2 different durations in transition and animations like here:

```css
.slide-leave-active { 
    animation: slide-out 1s ease-out forwards;
    transition: opacity 3s;
    opacity: 0;
}
```

By default Vue will apply the longest. We can specify the duration we want to use using this attribute:

```html
<!-- 
Type will specify wich duration of wich element use, can assign animation or transition values 
I this case the vue transition will finish when animation finishes.
--> 
<transition name="slide" type="animation"> 
    <div class="alert alert-info" v-if="show">This is some info</div>
</transition>
```

### 08.05 Animation initial load

Add the appear attribute to transition tag to animate the element when it's added to the DOM by first time. The transition dispatcher are ```*-enter``` and ```*-enter-active```:

```html
<transition name="fade" appear> <!-- Vue will attach CSS classes: fade-enter, fade-enter-active, fade-leave & fade-leave-active -->
    <div class="alert alert-info" v-if="show">This is some info</div>
</transition>
```

### 08.06 Transition between elements

*Important*
Remember, inside transition tag only one element can be visible at a time. 
In case we have more than one element we must use ```v-if```, v-show won't works because with v-show actually both elements will be in the DOM.

We need to specify the key attribute because when using the same element twice (like in the same with div) Vue cann't differentiate. Only need to specify key attrib. and will switch between them.

The mode attribute has 2 possible values:
 - out-in: the old element animates the out first, then the new element animates the in.
 - in-out: the new element animates the in first, then the old element animates the out.

If we omit the mode attrib. the 2 elements will start the transitions at the same time, so it will exists in the DOM at the same time for the period of the transition it's executed, so it can have some strange behaviour.
```html
<transition name="fade" mode="out-in"> 
    <div class="alert alert-info" v-if="show" key="info">This is some info</div>
    <div class="alert alert-warning" v-else key="warning">This is some Warning!</div>
</transition>
```

