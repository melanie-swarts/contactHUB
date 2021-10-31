<template>
  <div class="dashboard-editor-container">
    <div class="dashboard-heading">Hi {{ user.systemUser.firstName }}, welcome to your contactHUB.</div>
    <v-container fluid>
      <v-row style="height: 320px;">
        <v-col md="4" sm="12">
          <v-flex>
            <dash-card-list
              v-if="toDoItems"
              :card-name="'ToDo List'"
              :chart-colors="[`${chartColors['orange']}`]"
              :add="true"
              :settings="true"
              :list-items="toDoItems"

            />
          </v-flex>

        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>

import { mapState } from 'vuex'
import moment from 'moment'
import store from '@/store/store'
// import Storage from '@/classes/Storage.js'
// import DashCardChart from './components/DashCardChart.vue'
// import DashCardList from './components/DashCardList.vue'
// import TasksReminders from './components/TasksReminders.vue'
// import { ChartColors } from '@/store/modules/enums'
// import { VueFrappe } from 'vue2-frappe'

import ToDoList from './components/ToDoList'

export default {
  name: 'DashboardAdmin',
  components: {
    // DashCardChart,
    // DashCardList,
    // PanelGroup,
    // TasksReminders,
    // VueFrappe,
    // ChartColors,
    ToDoList
  },
  data() {
    return {
      showAddDialog: false,
      chartColors: ChartColors,
      typeName: '',
      toDoItems: [],
       model: 0,
    }
  },
    computed: {
    ...mapState(['user'])
  },
  created() {
    if (store.getters.userProfile === false) {
      this.$router.push({ name: 'CreateAccount' })
    }

    if (store.getters.systemUser.length === 0) {
      this.getSystemUser()
    }
    this.getToDos()
  },
  methods: {
    getWeeklyData(data) {
      var weekly = this.getWeeklyDataObject(data)
      var actualData = [0, 0, 0, 0, 0, 0, 0]
      for (let i = 0, len = weekly.length; i < len; i++) {
        const id = weekly[i].day
        actualData[id] = weekly[i].count
      }
      return actualData
    },
    async getToDos() {
      var storage = new Storage()
      var result = await storage.get('todos').where('UserId', 'eq', this.$store.getters.user.userId).orderByDesc('DueDate')
      this.toDoItems = result

      return result
    },
    // ----------------------------------------------------------------------------------------
    getSystemUser() {
      return this.$store.dispatch('fetchSystemUser')
    },
    formatDate(date) {
      return moment(date).format('d')
    }
  }
}
</script>

<style rel="stylesheet/scss" lang="scss" scoped>
.dashboard-editor-container {
  padding: 25px;
  background-color: rgb(240, 242, 245);
  .dashboard-heading{
    text-align: center;
    color: #999;
    font-size: 40px;
    margin-top: 10px;
    padding-bottom: 35px;
  }
}
</style>
