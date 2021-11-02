/* Layout */
import store from '@/store/store'
import Layout from '@/views/layout/Layout'
import Vue from 'vue'
import Router from 'vue-router'
import { BIconArrowCounterclockwise } from 'bootstrap-vue'

Vue.use(Router)

/** note: Submenu only appear when children.length>=1
 *  detail see  https://panjiachen.github.io/vue-element-admin-site/guide/essentials/router-and-nav.html
 **/

/**
* hidden: true                   if `hidden:true` will not show in the sidebar(default is false)
* alwaysShow: true               if set true, will always show the root menu, whatever its child routes length
*                                if not set alwaysShow, only more than one route under the children
*                                it will becomes nested mode, otherwise not show the root menu
* redirect: noredirect           if `redirect:noredirect` will no redirect in the breadcrumb
* name:'router-name'             the name is used by <keep-alive> (must set!!!)
* meta : {
    roles: ['admin','user']     will control the page roles (you can set multiple roles)
    title: 'title'               the name show in submenu and breadcrumb (recommend set)
    icon: 'svg-name'             the icon show in the sidebar,
    noCache: true                if true ,the page will no be cached(default is false)
  }
**/
export const constantRouterMap = [
  {
    path: '/redirect',
    component: Layout,
    hidden: true,
    children: [
      {
        path: '/redirect/:path*',
        component: () => import('@/views/redirect/index')
      }
    ]
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('@/views/login/index'),
    hidden: true
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import('@/views/account/register'),
    hidden: true
  },
  {
    path: '/new-password',
    name: 'NewPassword',
    component: () => import('@/views/account/newpassword'),
    hidden: true
  },
  {
    path: '/reset-password',
    name: 'ResetPassword',
    component: () => import('@/views/account/resetpassword'),
    hidden: true
  },
  {
    path: '/auth-redirect',
    component: () => import('@/views/login/authredirect'),
    hidden: true
  },
  {
    path: '/404',
    component: () => import('@/views/errorPage/404'),
    hidden: true
  },
  {
    path: '/401',
    component: () => import('@/views/errorPage/401'),
    hidden: true
  },
  {
    path: '',
    component: Layout,
    redirect: 'dashboard',
    children: [
      {
        path: 'dashboard',
        component: () => import('@/views/dashboard/index'),
        name: 'Dashboard',
        meta: { title: 'dashboard', icon: 'dashboard', noCache: true }
      }
    ]
  }
]

export default new Router({
  mode: 'history', // require service support
  scrollBehavior: () => ({ y: 0 }),
  routes: constantRouterMap
})

export const asyncRouterMap = [
  {
    path: '/contacts',
    component: Layout,
    name: 'Contact',
    meta: {title: 'Contacts', icon: 'peoples' },
    children: [
      {
        path: 'index',
        component: () => import('@/views/contacts/index'),
        name: 'Contacts',
        meta: { title: 'Contacts' }
      },
      {
        hidden: true,
        path: 'newContact',
        component: () => import('@/views/contacts/newContact'),
        name: 'NewContact',
        meta: { title: 'New Contact' }
      },
      {
        hidden: true,
        path: 'contactInformation/:id?',
        component: () => import('@/views/contacts/contactInformation'),
        name: 'ContactInfo',
        props: true,
        meta: { title: 'Contact Information' },
        beforeEnter(routeTo, routeFrom, next) {
          store
          .dispatch('contacts/fetchContact', routeTo.params.id)
          .then(selectedContact => {
              routeTo.params.selectedContact = selectedContact
              next()
            })
            .catch(error => {
              if (error.response && error.response.status === 404) {
                next({ name: '404', params: { resource: 'contacts' }})
              }
            })
        }
      }
    ]
  },
  {
    path: '/calendar',
    component: Layout,
    children: [
      {
        path: 'index',
        component: () => import('@/views/calendar/index'),
        name: 'Calendar',
        meta: { title: 'Calendar', icon: 'edit' }
      }
    ]
  },
  {
    hidden: true,
    path: '/lookups',
    component: Layout,
    children: [
      {
        path: 'index',
        component: () => import('@/views/lookups/index'),
        name: 'Lookups',
        meta: { title: 'Lookups', icon: 'tab' }
      },
      {
        hidden: true,
        path: 'calendarEventType/:id?',
        component: () => import('@/views/lookups/calendarEventTypes/calendarEventType'),
        name: 'CalendarEventType',
        props: true,
        meta: { title: 'Calendar Event Type' },
        beforeEnter(routeTo, routeFrom, next) {
          store
            .dispatch('calendarEventTypes/fetchCalendarEventTypes', routeTo.params.id)
            .then(selectedEventType => {
              routeTo.params.selectedCalendarEventType = selectedEventType
              next()
            })
            .catch(error => {
              if (error.response && error.response.status === 404) {
                next({ name: '404', params: { resource: 'cases' }})
              }
            })
        }
      },
      {
        path: 'newCalendarEventType',
        hidden: true,
        component: () => import('@/views/lookups/calendarEventTypes/newCalendarEventType'),
        name: 'NewCalendarEventType',
        meta: { title: 'New Calendar Event Type' }
      },
    ]
  },
  {
    path: '/userAccount',
    hidden: true,
    component: Layout,
    name: 'Profile',
    meta: {title: 'Profile', icon: 'user' },
    children: [
      {
        path: 'index',
        component: () => import('@/views/userAccount/index'),
        name: 'UserDetails',
        meta: { title: 'My Details' }
      },
      {
        path: 'changePassword',
        component: () => import('@/views/userAccount/changePassword'),
        name: 'ChangePassword',
        meta: { title: 'Change Password' }
      }
    ]
  },
  {
    path: '/userAccount',
    component: Layout,
    hidden: true,
    children: [
      {
        hidden: true,
        path: 'index',
        component: () => import('@/views/userAccount/index'),
        name: 'Account',
        meta: { title: 'My Account', icon: 'tab' }
      },
      {
        hidden: true,
        path: 'register',
        component: () => import('@/views/userAccount/create'),
        name: 'CreateAccount',
        meta: { title: 'Create Account', icon: 'tab' }
      }
    ]
  },
  { path: '*', redirect: '/404', hidden: true }
]
