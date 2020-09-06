<template>
<div>
    <h3>Edit the User</h3>
    <p> Edit the user {{ id }}</p>
    <p> Locale: {{ $route.query.locale }}</p>
    <p> q: {{ $route.query.q }}</p>
    <div style="height: 700px">
    </div>
    <p id="data">Some data at the bottom of the page</p>

</div>
</template>
<script>
export default {
    props: ['id']
}
</script>