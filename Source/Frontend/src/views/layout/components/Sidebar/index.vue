<template>
  <el-scrollbar wrap-class="scrollbar-wrapper">
    <el-menu
      :show-timeout="200"
      :default-active="$route.path"
      :collapse="isCollapse"
      mode="vertical"
      background-color="#3C565B"
      text-color="#fff"
      active-text-color="#fff"
    >
      <div class="container" style="padding: 16px">
        <img class="logo" src="@/assets/images/logo.png" alt="ContactHub">
      </div>
      <sidebar-item
        v-for="route in permission_routers"
        :key="route.name"
        :item="route"
        :base-path="route.path"
        :roles="userRoles"

      />
    </el-menu>

      <v-speed-dial
        v-if="!isCollapse"
        v-model="fab"
        :top="top"
        :bottom="bottom"
        :right="right"
        :left="left"
        :direction="direction"
        :open-on-hover="hover"
        :transition="transition"
      >
        <template v-slot:activator>
          <v-btn
            v-model="fab"
            color="blue darken-2"
            dark
            fab
          >
            <v-icon v-if="fab">mdi-close</v-icon>
            <v-icon v-else>mdi-cog</v-icon>
          </v-btn>
        </template>

        <v-tooltip right>
          <template v-slot:activator="{ on }">
            <v-btn
              small
              dark
              fab
              color="amber"
              v-on="on"
              @click="selectChangePassword()"
            >
              <v-icon>mdi-shield-account</v-icon>
            </v-btn>
          </template>
          <span>Change Password</span>
        </v-tooltip>

         <v-tooltip right>
          <template v-slot:activator="{ on }">
            <v-btn
              small
              dark
              fab
              color="purple lighten-1"
              v-on="on"
              @click="selectMyAccount()"
            >
              <v-icon>mdi-account-edit</v-icon>
            </v-btn>
          </template>
          <span>My Account</span>
        </v-tooltip>

      </v-speed-dial>
  </el-scrollbar>
</template>

<script>
import { mapGetters } from 'vuex'
import SidebarItem from './SidebarItem'

export default {
  components: { SidebarItem },
  data() {
    return {
      direction: 'top',
      fab: false,
      fling: false,
      hover: false,
      tabs: null,
      top: false,
      right: false,
      bottom: true,
      left: true,
      transition: 'slide-x-transition',
      userRoles: [],
      permissions: []
    }
  },
  computed: {
    ...mapGetters(['permission_routers', 'sidebar']),
    isCollapse() {
      return !this.sidebar.opened
    },
    activeFab() {
      switch (this.tabs) {
        case 'one': return { class: 'purple', icon: 'account_circle' }
        case 'two': return { class: 'red', icon: 'edit' }
        case 'three': return { class: 'green', icon: 'keyboard_arrow_up' }
        default: return {}
      }
    }
  },
  created() {
    this.userRoles = this.$store.state.user.roles
  },
  methods: {
    selectChangePassword() {
      this.$router.push({ name: 'ResetPassword' })
    },

    selectMyAccount(){
      this.$router.push({ name: 'UserDetails' })
    }
  }
}
</script>

<style rel="stylesheet/scss" lang="scss">

    .logo{
      width: 180px;
      height: auto;
      display: block;
      margin-left: auto;
      margin-right: auto;
    }

.v-application ul {
  padding-left: 0;
}

.el-menu-item.is-active {
  background-color: #5E7D7E;
}

  #create .v-speed-dial {
    position: absolute;
  }

.v-speed-dial__list{
  left: -90px !important;
}
.v-speed-dial{
  bottom: 80px!important
}
  #create .v-btn--floating {
    position: relative;
  }
</style>
