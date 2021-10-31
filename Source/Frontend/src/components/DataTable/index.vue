<template>
  <v-card>
    <v-card-title>
      <v-spacer/>
      <v-text-field v-model="search" append-icon="search" label="Search" single-line hide-details/>
    </v-card-title>
    <v-data-table :headers="headers" :items="data">
      <template slot="items" slot-scope="props">
        <td v-for="header in headers">
          <tr v-if="header.type != null">{{ props.item[header.value].Name }}</tr>
          <tr v-else>{{ props.item[header.value] }}</tr>
        </td>
      </template>
      <v-alert
        slot="no-results"
        :value="true"
        color="error"
        icon="warning"
      >Your search for "{{ search }}" found no results.</v-alert>
    </v-data-table>
  </v-card>
</template>

<script>
export default {
  name: 'DataTable',
  props: {
    data: Array,
    headers: Array
  }
}
</script>
