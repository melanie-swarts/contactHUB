<template>
  <div class="dashboard-container">
    <component :is="currentRole"/>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import userDashboard from './admin'

export default {
  name: 'Dashboard',
  components: { userDashboard },
  data() {
    return {
      currentRole: 'userDashboard'
    }
  },
  computed: {
    ...mapGetters([
      'roles'
    ])
  }
}
</script>
