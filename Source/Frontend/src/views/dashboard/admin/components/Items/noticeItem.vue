<template>
  <div>
    <v-list-item @click.stop="showItemDetails(item)">
      <template v-slot:default="{ active }">
        <v-list-item-avatar>
          <v-icon :color="item.IconColor" >mdi-alert-circle-outline</v-icon>
        </v-list-item-avatar>
        <v-list-item-content>
          <v-list-item-title :class="{done: item.Done}"><a>{{ item.Title }}</a></v-list-item-title>
          <v-list-item-subtitle>{{ item.Date }}</v-list-item-subtitle>
        </v-list-item-content>
        <v-tooltip bottom>
          <template v-slot:activator="{ on, attrs}">
            <v-icon v-bind="attrs" color="grey lighten-1" v-on="on" @click.stop="removeNotice(item)">mdi-close</v-icon>
          </template>
          <span>Delete Notice</span>
        </v-tooltip>

      </template>
    </v-list-item>
  </div>
</template>

<script>
import { CaseStatusColors } from '@/store/modules/enums.js'
export default {
  props: {
    item: {
      type: Object,
      default: null
    },
    idx: {
      type: Number,
      default: null
    },
    color: {
      type: String,
      default: ''
    },
    iconColor: {
      type: String,
      default: ''
    }
  },
  data() {
    return {
      colors: CaseStatusColors,
      showAddDialog: false,
      newTodo: '',
      active: false,
      showAddToDo: false
    }
  },
  methods: {
    removeNotice(notice) {
      this.$store.dispatch('notices/removeNotice', notice)
        .then(response => {
          this.$emit('remove-item', this.idx)
        })
        .catch(err => {
          console.log('Remove Notice ERROR: ', err)
        })
    },
    showItemDetails(notice) {
      this.$router.push({ name: 'Case', params: { id: notice.CaseId }})
    }
  }

}
</script>

<style scoped>
.done {
  text-decoration: line-through;
}

</style>
