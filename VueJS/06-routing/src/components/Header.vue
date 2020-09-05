<template>
<div>
        <!-- As a heading -->
        <b-navbar variant="faded" type="light">
            <b-navbar-brand >
                <!-- 
                <a class="nav-link" href="#">Active</a> 
                If we use <a> tag, the link will send a request to the server, then the server
                will be a behaviour that we expected and the touter will handle the request,
                but in first place, it's useless to leave the application to go to the server.
                Instead using <a> we can use an alternativo provided for VueJs: <router-link></router-link>
                This tag will produce an <a> tag a the end but with a click listener attached to it that
                ovewrites the default behaviour of send a request to the server.
                -->
                <router-link to="/">Home</router-link>
            </b-navbar-brand>
            <b-navbar-brand>
                <router-link to="/user/10">User 10</router-link>
            </b-navbar-brand>
            <b-navbar-brand>
                <router-link to="/user/3327">User 3327</router-link>
            </b-navbar-brand>
            <b-navbar-brand>
                <router-link to="/user">List of users</router-link>
            </b-navbar-brand>
        </b-navbar>
</div>
</template>