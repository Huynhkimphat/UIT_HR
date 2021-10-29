import Vue from 'vue'
import VueRouter from 'vue-router'
import store from '../store/index'

Vue.use(VueRouter)

const routes = [
  {
    path: '/admin/dashboard',
    name: 'adminDashboard',
    component: () => import('@/views/admin/dashboard/Dashboard.vue'),
    meta: {
      requiresAuth: true,
      adminAuth: true,
    },
  },
  {
    path: '/admin/employee',
    name: 'adminEmployee',
    component: () => import('@/views/admin/employee/Employee.vue'),
    meta: {
      requiresAuth: true,
      adminAuth: true,
    },
  },
  {
    path: '/admin/holiday',
    name: 'adminHoliday',
    component: () => import('@/views/admin/holiday/Holiday.vue'),
    meta: {
      requiresAuth: true,
      adminAuth: true,
    },
  },
  {
    path: '/',
    redirect: 'dashboard',
  },
  {
    path: '/dashboard',
    name: 'dashboard',
    component: () => import('@/views/dashboard/Dashboard.vue'),
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: '/typography',
    name: 'typography',
    component: () => import('@/views/typography/Typography.vue'),
  },
  {
    path: '/icons',
    name: 'icons',
    component: () => import('@/views/icons/Icons.vue'),
  },
  {
    path: '/cards',
    name: 'cards',
    component: () => import('@/views/cards/Card.vue'),
  },
  {
    path: '/simple-table',
    name: 'simple-table',
    component: () => import('@/views/simple-table/SimpleTable.vue'),
  },
  {
    path: '/form-layouts',
    name: 'form-layouts',
    component: () => import('@/views/form-layouts/FormLayouts.vue'),
  },
  {
    path: '/pages/account-settings',
    name: 'pages-account-settings',
    component: () => import('@/views/pages/account-settings/AccountSettings.vue'),
  },
  {
    path: '/pages/login',
    name: 'pages-login',
    component: () => import('@/views/pages/Login.vue'),
    meta: {
      layout: 'blank',
    },

    beforeEnter: (to, from, next) => {
      if (store.getters.isLoggedIn) {
        next({ name: 'dashboard' })
      }
      next()
    },
  },
  {
    path: '/pages/register',
    name: 'pages-register',
    component: () => import('@/views/pages/Register.vue'),
    meta: {
      layout: 'blank',
    },
  },
  {
    path: '/error-404',
    name: 'error-404',
    component: () => import('@/views/Error.vue'),
    meta: {
      layout: 'blank',
    },
  },
  {
    path: '*',
    redirect: 'error-404',
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
})
router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.adminAuth)) {
    if (!store.getters.isLoggedIn) {
      next({ name: 'pages-login' })
    } else if (store.getters.getRole !== 'Admin') next({ name: 'dashboard' })
    else {
      next()
    }
  } else {
    next()
  }
})
export default router
