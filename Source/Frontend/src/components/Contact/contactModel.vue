<template>
  <v-card
    class="mx-left"
    max-width="50%"
    outlined
  >
    <v-list dense>
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="headline mb-1 pt-1" style="height:30px;">{{ contactModel.Name }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-list-item>
        <v-list-item-icon>
          <v-icon color="#3C565B">mdi-email</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-subtitle><a :href="'mailto:' + contactModel.Email">{{ contactModel.Email }}</a></v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
      <v-list-item>
        <v-list-item-icon>
          <v-icon color="#3C565B">mdi-phone</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-subtitle>{{ contactModel.ContactNumber }}</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
      <v-list-item>
        <v-list-item-icon>
          <v-icon color="#3C565B">mdi-home-city</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-subtitle>{{ contactModel.Address }}</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script>
export default {
  props: {
    contactModel: {
      type: Object,
      required: true
    }
  }
}
</script>
