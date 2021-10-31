<template>
  <div class="nav-tabs-custom">
    <ul :class="tabsClass" class="nav nav-tabs">
      <li v-for="(tab, index) in tabList" :data="tab" :key="index" :class="tab.class">
        <a :href="tab.id" data-toggle="tab">{{ tab.title }}</a>
      </li>
      <slot name="nav"/>
    </ul>
    <div class="tab-content">
      <slot name="content" class="tab-pane"/>
    </div>
  </div>
</template>

<script>
export default {
  name: 'CustomTab',
  props: {
    tabsClass: {
      type: String,
      default: ''
    }
  },
  data() {
    return {
      tabList: []
    }
  },
  mounted() {
    for (const i in this.$slots.content) {
      var vm = this.$slots.content[i]

      if (typeof vm !== 'object') {
        continue
      }
      vm.elm.className += ' tab-pane'
      this.tabList.push({
        id: '#' + vm.data.attrs.id,
        class: vm.data.staticClass || '',
        title: vm.data.attrs.title
      })
    }
  }
}
</script>

