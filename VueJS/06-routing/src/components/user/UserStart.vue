<template>
    <div>
        <p>You see this component because you access to '/user' route.
            If you access to '/user/10' will be access to User component but that route match with defined route that hasn't any sub route, so this component won't be visible.
            If you access to '/user' the route will match with a defined route that show User component and also has children routes and in adition has a children with an empty path that show this component! 
        </p>

        <p>Please select a User</p>
        
        <ul class="list-group">
            <router-link tag="li" to="/user/us/1" class="list-group-item" style="cursor: pointer">User 1</router-link>
            <router-link tag="li" to="/user/us/2" class="list-group-item" style="cursor: pointer">User 2</router-link>
            <router-link tag="li" to="/user/us/3" class="list-group-item" style="cursor: pointer">User 3</router-link>
        </ul>
    </div>
</template>