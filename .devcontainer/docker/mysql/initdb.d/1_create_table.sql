DROP TABLE IF EXISTS `mst_batch`;
CREATE TABLE `mst_batch` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

DROP TABLE IF EXISTS `batch_queue`;
CREATE TABLE `batch_queue` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `mst_batch_id` bigint NOT NULL,
  `status` tinyint NOT NULL COMMENT '1:regist, 2:execute, 3:end, 4:fail',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

DROP TABLE IF EXISTS `batch_journal`;
CREATE TABLE `batch_journal` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `batch_queue_id` bigint NOT NULL,
  `text` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;