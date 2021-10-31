<template>
  <div>
  <div class="userInfo-container">
    <div class="userInfo-dashboard-text">My Details</div>
  </div>
 <v-card>
        <v-card flat>
          <personal-details />
        </v-card>

  </v-card>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import store from '@/store/store'
import moment from 'moment'
import PersonalDetails from './personalDetails'

export default {
    components: {
    PersonalDetails
  },
    data () {
      return {
        search: '',
        formattedDate: null
      }
    },
  computed: {
    ...mapState(['user'])
  },
  created() {

  },
  methods: {
    formatDate(date) {
      return moment(date, 'YYYY-MM-DD').format('DD MMMM YYYY')
    }
  }
}
</script>

<style rel="stylesheet/scss" lang="scss">
.basil {
  background-color: #FFFBE6 !important;
}
.basil--text {
  color: #356859 !important;
}
.wrapper{
    height:auto; 
}

.user-personal-info-1{
  font-size: 12px;
  font-weight: 400;
  color: gray;
  float:left; 
  clear: left;
  padding-left: 10px;
}

.user-personal-info{
    font-size: 12px;
    font-weight: 400;
    color: gray;
    float:left; 
    clear: left;
    padding-left: 10px;
    padding-bottom: 5px;
}

.userInfo-container {
  background-color: rgb(240, 242, 245);

  .userInfo-dashboard-text{
    text-align: center;
    color: #999;
    font-size: 45px;
    margin-top: 15px;
    padding-bottom: 10px;
  }
}

.v-tabs__item--disabled{
  background-color:lightgray;
}
</style>
