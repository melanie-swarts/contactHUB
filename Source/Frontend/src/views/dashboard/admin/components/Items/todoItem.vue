<template>
  <div>
    <v-list-item>
      <template v-slot:default="{ active }">
        <v-list-item-action>
          <v-checkbox v-model="item.Done" :color="color" @click="toggleDone(item)"/>
        </v-list-item-action>
        <v-list-item-content>
          <v-list-item-title :class="{done: item.Done}">{{ item.Title }}</v-list-item-title>
          <v-list-item-subtitle :class="{done: item.Done}">{{ item.DueDate }}</v-list-item-subtitle>
        </v-list-item-content>

        <span v-if="item.Done">
          <v-tooltip bottom>
            <template v-slot:activator="{ on, attrs }">
              <v-icon v-bind="attrs" color="grey lighten-1" v-on="on" @click="removeTodo(item)">mdi-close</v-icon>
            </template>
            <span>Delete ToDo</span>
          </v-tooltip>
        </span>

        <v-tooltip bottom>
          <template v-slot:activator="{ on, attrs }">
            <v-icon v-if="item.Priority === 0" v-bind="attrs" :color="`${colors[item.Priority]}`" v-on="on" @click.stop="changePriority(item)" >mdi-star-outline</v-icon>
            <v-icon v-else v-bind="attrs" :color="`${colors[item.Priority]}`" v-on="on" @click.stop="changePriority(item)" >mdi-star</v-icon>
          </template>
          <span>Change Priority</span>
        </v-tooltip>
      </template>
    </v-list-item>
  </div>
</template>

<script>
import { CaseStatusColors } from '@/store/modules/enums.js'
import Dates from '@/store/modules/dates.js'
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
  computed: {

  },
  methods: {
    formatDate(d) {
      return Dates.formatDate(d)
    },
    removeTodo(todo) {
      this.$store.dispatch('toDos/removeToDo', todo)
        .then(response => {
          this.$emit('remove-item', this.idx)
        })
        .catch(err => {
          console.log('Remove ToDo ERROR: ', err)
        })
    },
    changePriority(todo) {
      var newPriority = todo.Priority = (todo.Priority + 1)
      if (newPriority > 3) {
        newPriority = 0
      }

      todo.Priority = newPriority

      this.$store.dispatch('toDos/updateToDo', todo)
        .then(response => {
        })
        .catch(err => {
          console.log('Update ToDO ERROR: ', err)
        })
    },
    toggleDone(todo) {
      this.$store.dispatch('toDos/updateToDo', todo)
        .then(response => {
        })
        .catch(err => {
          console.log('Update ToDo ERROR: ', err)
        })
    }

  }

}
</script>

<style scoped>
.done {
  text-decoration: line-through;
}

</style>
