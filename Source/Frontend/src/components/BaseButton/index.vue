<template>
  <div>
    <button v-bind="$attrs" :class="buttonClass" class="button" v-on="$listeners">
      <slot/>
    </button>
  </div>
</template>

<script>
export default {
  name: 'BaseButton',
  inheritAttrs: false,
  props: {
    buttonClass: {
      type: String
    }
  }
}
</script>
